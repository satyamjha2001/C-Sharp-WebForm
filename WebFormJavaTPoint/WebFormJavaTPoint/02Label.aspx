<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02Label.aspx.cs" Inherits="WebFormJavaTPoint.Label" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Provide the Following Details:</h4>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="label1" runat="server" AssociatedControlID="TextBox1">User Name</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter Your Name" TabIndex="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label2" runat="server" AssociatedControlID="FileUpload1">Upload a file</asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script>
        const a = 23;
        let b = 45;
        let c = a + b;
        console.log(c);
    </script>
</body>
</html>
