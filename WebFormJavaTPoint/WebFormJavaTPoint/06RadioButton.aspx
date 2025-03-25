<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="06RadioButton.aspx.cs" Inherits="WebFormJavaTPoint._06RadioButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButton GroupName="Gender" ID="M" Text="Male" Checked="true" runat="server" />
            <asp:RadioButton GroupName="Gender" ID="F" Text="Female" runat="server" />
            <p>
                <asp:Button ID="SubmitButton" Text="Submit" onKeyUp="" runat="server" OnClick="SubmitButtoN_Click" />
            </p>
        </div>
    </form>
    <p>
        <asp:Label ID="genderId" runat="server"></asp:Label>
    </p>
</body>
</html>
