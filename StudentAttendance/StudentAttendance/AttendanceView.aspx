<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceView.aspx.cs" Inherits="StudentAttendance.AttendanceView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="homeButton" runat="server" OnClick="homeButton_Click">Back to Home</asp:LinkButton>
        <br />
        <asp:LinkButton ID="logoutButton" runat="server" OnClick="logoutButton_Click">Log Out</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
