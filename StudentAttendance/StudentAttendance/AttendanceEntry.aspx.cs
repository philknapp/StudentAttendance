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

                string countClass = "Select COUNT(*) from CourseSession WHERE courseID = @course";
                SqlCommand findClass = new SqlCommand(countClass, conn);
                findClass.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                int foundClass = (Int32)findClass.ExecuteScalar();
                

                string countCourseDate = "SELECT COUNT(*) FROM CourseSession WHERE courseDate = @Date";
                SqlCommand findDate = new SqlCommand(countCourseDate, conn);
                findDate.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundDate = (Int32)findDate.ExecuteScalar();
                

                if (foundClass == 0 && foundDate == 0)
                {
                    string insertQuery = "insert into CourseSession (courseID, courseDate) values (@courseID, @courseDate)";
                    SqlCommand com = new SqlCommand(insertQuery, conn);

                    com.Parameters.AddWithValue("@courseID", classDropDown.SelectedValue);
                    com.Parameters.AddWithValue("@courseDate", SqlDbType.DateTime).Value = Calendar1.SelectedDate;

                    com.ExecuteNonQuery();

                    Response.Write("You have successfully created a new session!");

                }

                string studentQuery = "Select COUNT(*) from CourseAttendance WHERE studentID = @student";
                SqlCommand findStudent = new SqlCommand(studentQuery, conn);
                findStudent.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                int foundStudent = (Int32)findStudent.ExecuteScalar();
                    

                string countClassAttendance = "Select COUNT(*) from CourseAttendance WHERE courseID = @course";
                SqlCommand findClassAttendance = new SqlCommand(countClassAttendance, conn);
                findClassAttendance.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                int foundClassAttendance = (Int32)findClass.ExecuteScalar();
                    

                string countCourseDateAttendance = "SELECT COUNT(*) FROM CourseAttendance WHERE courseDate = @Date";
                SqlCommand findDateAttendance = new SqlCommand(countCourseDateAttendance, conn);
                findDateAttendance.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundDateAttendance = (Int32)findDate.ExecuteScalar();
                    

                if (foundStudent == 0 || foundClassAttendance == 0 || foundDateAttendance == 0)
                {
                    string insertQuery2 = "insert into CourseAttendance (courseID, courseDate, studentID) values (@courseID, @courseDate, @studentID)";
                    SqlCommand com2 = new SqlCommand(insertQuery2, conn);

                    com2.Parameters.AddWithValue("@courseID", classDropDown.SelectedValue);
                    com2.Parameters.AddWithValue("@courseDate", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                    com2.Parameters.AddWithValue("@studentID", studentDropDown.SelectedValue);

                    com2.ExecuteNonQuery();

                    Response.Write("You have successfully created a new attendance entry for  " + studentDropDown.SelectedItem + " On " + Calendar1.SelectedDate);

                }

                else
                {
                    Response.Write("Attendance entry for this Student already exists for this date");
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

                string studentQuery = "Select COUNT(*) from CourseAttendance WHERE studentID = @student";
                SqlCommand findStudent = new SqlCommand(studentQuery, conn);
                findStudent.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                int foundStudent = (Int32)findStudent.ExecuteScalar();

                string countClassAttendance = "Select COUNT(*) from CourseAttendance WHERE courseID = @course";
                SqlCommand findClassAttendance = new SqlCommand(countClassAttendance, conn);
                findClassAttendance.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                int foundClassAttendance = (Int32)findClassAttendance.ExecuteScalar();

                string countCourseDateAttendance = "SELECT COUNT(*) FROM CourseAttendance WHERE courseDate = @Date";
                SqlCommand findDateAttendance = new SqlCommand(countCourseDateAttendance, conn);
                findDateAttendance.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                int foundDateAttendance = (Int32)findDateAttendance.ExecuteScalar();

                if (foundStudent == 1 && foundClassAttendance == 1 && foundDateAttendance == 1)
                {
                    string deleteAttendance = "Delete FROM CourseAttendance WHERE studentID = @student AND courseID = @course AND courseDate = @Date";
                    SqlCommand deleteAttendanceEntry = new SqlCommand(deleteAttendance, conn);
                    deleteAttendanceEntry.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = Calendar1.SelectedDate;
                    deleteAttendanceEntry.Parameters.AddWithValue("@course", classDropDown.SelectedValue);
                    deleteAttendanceEntry.Parameters.AddWithValue("@student", studentDropDown.SelectedValue);
                    deleteAttendanceEntry.ExecuteNonQuery();

                }
                else
                {
                    Response.Write("No entry to delete.");
                }
            }

            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }


        }
    }
}