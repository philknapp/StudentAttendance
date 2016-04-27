using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendance
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["New"] != null)
            {
                Response.Write("Welcome to Attendance Explorer!  ");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");

        }

        protected void regClassButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateClass.aspx");
        }

        protected void stuRegButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateStudent.aspx");
        }

        protected void enterAttendButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceEntry.aspx");
        }

        protected void viewAttendButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceView.aspx");
        }
    }
}