<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="04Button.aspx.cs" Inherits="WebFormJavaTPoint._04Button" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" Text="Click Me!" BorderStyle="Ridge" runat="server" OnClick="Button1_Click"/>
        </div>
    </form>
    <asp:Label ID="Label" runat="server" ></asp:Label>
</body>
</html>
