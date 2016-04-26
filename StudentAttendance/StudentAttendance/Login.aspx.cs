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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

            conn.Open();

            string checkuser = "select count(*) from Registration where Username ='" + usernameBox.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);

            int userCount = Convert.ToInt32(com.ExecuteScalar().ToString());

            conn.Close();

            if (userCount == 1)
            {
                conn.Open();

                string credentials = "select password from Registration where Username = '" + usernameBox.Text + "'";
                SqlCommand passCom = new SqlCommand(credentials, conn);
                string password = passCom.ExecuteScalar().ToString().Replace(" ","");

                if(password == passwordBox.Text)
                {
                    Session["New"] = usernameBox.Text;
                    Response.Redirect("Students.aspx");
                }
                else
                {
                    Response.Write("Password is incorrect.");
                }

            }
            else
            {
                Response.Write("Username does not exist, please register an account.");
            }

            

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}