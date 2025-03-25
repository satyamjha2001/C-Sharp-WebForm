<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Session_State.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="UserName"  runat="server" >UserName:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Submit" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
