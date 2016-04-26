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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                com.Parameters.AddWithValue("@lastName", firstBox.Text);

                Response.Write("You have successfully created a new student!");

                conn.Close();



            }
            catch (SqlException ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
    }
}