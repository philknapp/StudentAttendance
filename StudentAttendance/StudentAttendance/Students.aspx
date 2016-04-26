<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="StudentAttendance.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="welcomeLabel" runat="server" Text="Welcome "></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="stuRegButton" runat="server" OnClick="stuRegButton_Click">Register a new student</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="regClassButton" runat="server" OnClick="regClassButton_Click">Register a new class</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="enterAttendButton" runat="server" OnClick="enterAttendButton_Click">Submit Attendance</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="viewAttendButton" runat="server" OnClick="viewAttendButton_Click">View Attendance</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="logoutButton" runat="server" OnClick="logoutButton_Click">Log out</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
