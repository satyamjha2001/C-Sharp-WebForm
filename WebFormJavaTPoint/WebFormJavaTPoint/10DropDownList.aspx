<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="10DropDownList.aspx.cs" Inherits="WebFormJavaTPoint._10DropDownList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Select a city of your chice: </h3>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="">Select Item</asp:ListItem>
                <asp:ListItem Value="New Delhi">New Delhi</asp:ListItem>
                <asp:ListItem Value="Noida">Noida</asp:ListItem>
                <asp:ListItem Value="Gurugram">Gurugram</asp:ListItem>
                <asp:ListItem Value="Bengaluru">Bengaluru</asp:ListItem>
            </asp:DropDownList>
            <p>
                <asp:Button ID="SubmitButton" onClick="SubmitButton_Clicked" runat="server" Text="Submit" />
            </p>
            <p>
                <asp:Label ID="ResultLabel" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
