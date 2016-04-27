using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendance
{
    public partial class AttendanceView : System.Web.UI.Page
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
    }
}