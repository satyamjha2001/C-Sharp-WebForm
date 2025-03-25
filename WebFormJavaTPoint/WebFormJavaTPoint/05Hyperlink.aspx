<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="05Hyperlink.aspx.cs" Inherits="WebFormJavaTPoint._05Hyperlink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="https://react.dev/">this is html hyperlink</a>
            <br />
            <asp:HyperLink NavigateUrl="https://www.javatpoint.com" Text="this is asp.net hyperlink" runat="server" />
            <br />
            <asp:HyperLink NavigateUrl="https://www.javatpoint.com" runat="server">JavaTpoint</asp:HyperLink>
        </div>
    </form>
</body>
</html>
