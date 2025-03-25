<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>My First Web Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Height="49px" OnClick="Button1_Click" Text="Click" Width="112px" />
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
