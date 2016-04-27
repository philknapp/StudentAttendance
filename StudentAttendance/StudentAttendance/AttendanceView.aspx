<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceView.aspx.cs" Inherits="StudentAttendance.AttendanceView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT Students.FirstName, Students.LastName, Courses.courseName FROM CourseAttendance INNER JOIN Courses ON CourseAttendance.courseID = Courses.courseID INNER JOIN CourseSession ON CourseAttendance.courseID = CourseSession.courseID INNER JOIN Students ON CourseAttendance.studentID = Students.studentID"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="courseName" HeaderText="courseName" SortExpression="courseName" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <br />
        <br />
    
        <asp:LinkButton ID="homeButton" runat="server" OnClick="homeButton_Click">Back to Home</asp:LinkButton>
        <br />
        <asp:LinkButton ID="logoutButton" runat="server" OnClick="logoutButton_Click">Log Out</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
