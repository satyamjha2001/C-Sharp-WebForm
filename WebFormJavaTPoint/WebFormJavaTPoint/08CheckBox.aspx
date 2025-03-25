<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="08CheckBox.aspx.cs" Inherits="WebFormJavaTPoint._08CheckBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Select Courses</h2>
            <asp:CheckBox ID="CheckBox1" Text="C++" runat="server"></asp:CheckBox>
            <asp:CheckBox ID="CheckBox2" Text="C#" runat="server"></asp:CheckBox>
            <asp:CheckBox ID="CheckBox3" Text="JavaScript" runat="server"></asp:CheckBox>
            <p>
                <asp:Button ID="Submit" Text="Submit" OnClick="SubmitButton" runat="server" /></p>
        </div>
    </form>
    Your Selected Courses is
    <asp:Label ID="ShowCourse" runat="server"></asp:Label>
</body>
</html>
