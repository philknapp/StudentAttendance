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
        <asp:Button ID="logoutButton" runat="server" OnClick="logoutButton_Click" Text="Log Out" />
    
    </div>
    </form>
</body>
</html>
