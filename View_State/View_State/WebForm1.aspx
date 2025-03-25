<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="View_State.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #RestoreButton {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td>UserName</td>
                    <td>
                        <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                        <asp:Button ID="RestoreButton" runat="server" Text="Restore" OnClick="RestoreButton_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
