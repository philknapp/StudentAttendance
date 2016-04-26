<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentAttendance.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            text-align: right;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
            text-align: left;
        }
        .auto-style9 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <div class="auto-style9">
    
        <table>
            <tr>
                <td> 
                    <strong><span class="auto-style3">Login Page</span></strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Username</td>
                <td class="auto-style9">
                    <asp:TextBox ID="usernameBox" runat="server" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernameBox" ErrorMessage="Please enter a username." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style6">Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passwordBox" ErrorMessage="Please enter a password. " ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style9">
                    <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Login" />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                </td>
                
            </tr>

        </table>
    
    </div>
    </form>
</body>
</html>
