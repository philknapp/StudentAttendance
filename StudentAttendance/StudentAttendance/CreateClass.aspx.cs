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
    public partial class WebForm2 : System.Web.UI.Page
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

            if (IsPostBack)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

                    conn.Open();

                    string checkuser = "select count(*) from Courses where courseName ='" + classBox.Text + "'";
                    SqlCommand com = new SqlCommand(checkuser, conn);

                    int userCount = Convert.ToInt32(com.ExecuteScalar().ToString());

                    if (userCount == 1)
                    {
                        Response.Write("That Class already exists.");
                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.ToString());
                }

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

        protected void classButton_Click(object sender, EventArgs e)
        {
            try
            {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

            string insertQuery = "insert into Courses (courseName) values (@courseName)";

            conn.Open();

            SqlCommand com = new SqlCommand(insertQuery, conn);

            com.Parameters.AddWithValue("@courseName", classBox.Text);

            com.ExecuteNonQuery();

            Response.Write("You have successfully created a new class!");

            conn.Close();

            GridView1.DataBind();

            }
            catch (SqlException ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
}
    }
}