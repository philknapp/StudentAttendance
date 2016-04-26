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
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void studentButton_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

                string insertQuery = "insert into Students (FirstName, LastName) values (@firstName, @lastName)";

                conn.Open();

                SqlCommand com = new SqlCommand(insertQuery, conn);

                com.Parameters.AddWithValue("@firstName", firstBox.Text);
                com.Parameters.AddWithValue("@lastName", lastBox.Text);

                com.ExecuteNonQuery();

                Response.Write("You have successfully created a new student!");

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