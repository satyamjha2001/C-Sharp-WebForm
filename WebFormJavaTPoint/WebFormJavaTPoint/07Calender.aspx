<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="07Calender.aspx.cs" Inherits="WebFormJavaTPoint._07Calender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <h2>Select a date from Calender</h2>
        <div>
            <asp:Calendar ID="Calender1" runat="server" OnSelectionChanged="Calender1_SelectionChanged"></asp:Calendar>
        </div>
    </form>
    <asp:Label ID="SelectedDate" runat="server"></asp:Label>
</body>
</html>
