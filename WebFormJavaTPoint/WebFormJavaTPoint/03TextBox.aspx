<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03TextBox.aspx.cs" Inherits="WebFormJavaTPoint._03TextBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Labelid" runat="server" AssociatedControlID="UserName">User Name: </asp:Label>
            <asp:TextBox ID="UserName" ToolTip="Enter Your Name" runat="server"></asp:TextBox>
        </div>
            <p>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" onClick="SubmitButton_Click" />
            </p>
        <asp:Label ID="userInput" runat="server"></asp:Label>
    </form>
</body>
</html>
