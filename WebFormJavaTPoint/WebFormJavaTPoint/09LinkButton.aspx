<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="09LinkButton.aspx.cs" Inherits="WebFormJavaTPoint._09LinkButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>This is hyperLink style button.</h1>
        <div>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Try Clicking...</asp:LinkButton>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
