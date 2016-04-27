<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceEntry.aspx.cs" Inherits="StudentAttendance.AttendanceEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Student:<br />
        <asp:DropDownList ID="studentDropDown" runat="server" DataSourceID="SqlDataSource1" DataTextField ="Name" DataValueField="studentID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    SelectCommand="SELECT [studentID], ([FirstName] + [lastName]) AS Name FROM [Students]" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>"></asp:SqlDataSource>
        <br />
        <br />
        Class:<br />
        <asp:DropDownList ID="classDropDown" runat="server" DataSourceID="SqlDataSource2" DataTextField="courseName" DataValueField="courseID">
        </asp:DropDownList>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT [courseID], [courseName] FROM [Courses]"></asp:SqlDataSource>
        <br />
        Date:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add Attendance" Width="160px" />
        <br />
        <asp:Button ID="deleteButton" runat="server" OnClick="deleteButton_Click" Text="Delete Attendance" Width="160px" />
        <br />
        <br />
        <asp:LinkButton ID="homeButton" runat="server" OnClick="homeButton_Click">Back to Home</asp:LinkButton>
        <br />
        <asp:LinkButton ID="logoutButton" runat="server" OnClick="logoutButton_Click">Log Out</asp:LinkButton>
    </div>
    </form>
</body>
</html>