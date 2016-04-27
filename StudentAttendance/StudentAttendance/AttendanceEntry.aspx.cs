using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentAttendance
{
    public partial class AttendanceEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                Response.Write("Welcome to Attendance Explorer!  ");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

            try
            {
                conn.Open();

                string sessionQuery = "Select COUNT(*) from CourseSession WHERE courseID = @course and courseDate = @Date";
                SqlCommand findSession = new SqlCommand(sessionQuery, conn);
                findSession.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                findSession.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundSession = (Int32)findSession.ExecuteScalar();       

                if (foundSession == 0)
                {
                    string insertQuery = "insert into CourseSession (courseID, courseDate) values (@courseID, @courseDate)";
                    SqlCommand com = new SqlCommand(insertQuery, conn);

                    com.Parameters.AddWithValue("@courseID", classDropDown.SelectedValue);
                    com.Parameters.AddWithValue("@courseDate", SqlDbType.DateTime).Value = Calendar1.SelectedDate;

                    com.ExecuteNonQuery();

                    Response.Write("You have successfully created a new session!");

                }
                   
                string countClassAttendance = "Select COUNT(*) from CourseAttendance WHERE courseID = @course and courseDate = @Date and studentID = @student";
                SqlCommand findClassAttendance = new SqlCommand(countClassAttendance, conn);
                findClassAttendance.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                findClassAttendance.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                findClassAttendance.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundClassAttendance = (Int32)findClassAttendance.ExecuteScalar();              


                if (foundClassAttendance == 0)
                {
                    string insertQuery2 = "insert into CourseAttendance (courseID, courseDate, studentID) values (@courseID, @courseDate, @studentID)";
                    SqlCommand com2 = new SqlCommand(insertQuery2, conn);

                    com2.Parameters.AddWithValue("@courseID", classDropDown.SelectedValue);
                    com2.Parameters.AddWithValue("@courseDate", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                    com2.Parameters.AddWithValue("@studentID", studentDropDown.SelectedValue);

                    com2.ExecuteNonQuery();

                    Response.Write("  You have successfully created a new attendance entry for  " + studentDropDown.SelectedItem + " On " + Calendar1.SelectedDate);

                }

                else
                {
                    Response.Write("  Attendance entry for this Student already exists for this date");
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
 
        

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            try
            {
                conn.Open();

                string countClassAttendance = "Select COUNT(*) from CourseAttendance WHERE courseID = @course and courseDate = @Date and studentID = @student";
                SqlCommand findClassAttendance = new SqlCommand(countClassAttendance, conn);
                findClassAttendance.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                findClassAttendance.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                findClassAttendance.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundClassAttendance = (Int32)findClassAttendance.ExecuteScalar();

                if (foundClassAttendance > 0)
                {
                    string deleteAttendance = "  Delete FROM CourseAttendance WHERE studentID = @student AND courseID = @course AND courseDate = @Date";
                    SqlCommand deleteAttendanceEntry = new SqlCommand(deleteAttendance, conn);
                    deleteAttendanceEntry.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                    deleteAttendanceEntry.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                    deleteAttendanceEntry.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                    deleteAttendanceEntry.ExecuteNonQuery();
                    Response.Write("  Deleted entry.");

                }
                else
                {
                    Response.Write("  No entry to delete.");
                }
            }

            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }


        }
    }
}