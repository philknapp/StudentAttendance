<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudentAttendance.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 124px;
        }
        .auto-style3 {
            width: 124px;
            text-align: right;
        }
        .auto-style4 {
            width: 334px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Username:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="userBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="userBox" ErrorMessage="Please enter a username." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Email:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailBox" ErrorMessage="Please enter an email address." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Password:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="pwBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pwBox" ErrorMessage="Please enter a password." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Confirm Password:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="pwconfirmBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pwconfirmBox" ErrorMessage="Please confirm password." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="registerButton" runat="server" Text="Register" />
                </td>
                <td class="auto-style4">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailBox" ErrorMessage="Please enter a valid email address." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
