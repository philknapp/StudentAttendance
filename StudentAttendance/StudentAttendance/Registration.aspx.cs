﻿using System;
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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(IsPostBack)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

                    conn.Open();

                    string checkuser = "select count(*) from Registration where Username ='" + userBox.Text + "'";
                    SqlCommand com = new SqlCommand(checkuser, conn);

                    int userCount = Convert.ToInt32(com.ExecuteScalar().ToString());

                    if (userCount == 1)
                    {
                        Response.Write("That username is already in use.");
                    }

                    conn.Close();
                }

                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.ToString());
                }

            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            try {
                Guid newGuid = Guid.NewGuid();

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

                conn.Open();

                string insertQuery = "insert into Registration (teacherID,Username,Email,Password) values (@teacherID, @username, @email, @password)";

                SqlCommand com = new SqlCommand(insertQuery, conn);

                com.Parameters.AddWithValue("@teacherID", newGuid.ToString());
                com.Parameters.AddWithValue("@Username",userBox.Text);
                com.Parameters.AddWithValue("@email", emailBox.Text);
                com.Parameters.AddWithValue("@password", pwBox.Text);

                com.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("Login.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
    }
}