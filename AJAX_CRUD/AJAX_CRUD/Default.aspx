<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAX_CRUD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script>
        var txtDOBClientID = '<%= txtDOB.ClientID %>'; // Store ASP.NET ClientID in JS variable
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName">Name</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtName" PlaceHolder="Enter name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valName" ErrorMessage="Name is required" ControlToValidate="txtName" SetFocusOnError="true" ForeColor="Red" runat="server">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" AssociatedControlID="txtMobile" runat="server">Mobile No.</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMobile" PlaceHolder="Enter Number" TextMode="Phone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valMobile" ErrorMessage="Mobile No. is required" ControlToValidate="txtMobile" SetFocusOnError="true" ForeColor="Red" runat="server">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Enter a valid 10-digit mobile number!" ValidationExpression="^[6-9]\d{9}$" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server">Email</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" TextMode="Email" PlaceHolder="Enter Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValEmail" ErrorMessage="Email is required" ControlToValidate="txtEmail" SetFocusOnError="true" ForeColor="Red" Display="Dynamic" runat="server">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegValEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email" SetFocusOnError="true" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGender" runat="server">Gender</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownGender" runat="server">
                            <asp:ListItem Value="">Select Gender</asp:ListItem>
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ErrorMessage="Please choose gender" ForeColor="Red" ControlToValidate="DropDownGender" runat="server">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHobbies" runat="server">Choose Hobbies</asp:Label></td>
                    <td>
                        <asp:CheckBox ID="chkCricket" Text="Playing Cricket" runat="server" />
                        <asp:CheckBox ID="chkFootball" Text="Playing Football" runat="server" />
                        <asp:CheckBox ID="chkReading" Text="Reading Books" runat="server" />
                        <asp:CheckBox ID="chkMovies" Text="Songs and Movies" runat="server" />
                        <asp:CustomValidator ID="valHobbies" runat="server" ErrorMessage="Please choose at least one hobby" ForeColor="Red" ClientValidationFunction="ValidateHobbies" OnServerValidate="ValidateHobbies">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOB" runat="server">DOB</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDOB" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valDOB" ErrorMessage="DOB is required" ControlToValidate="txtDOB" SetFocusOnError="true" ForeColor="Red" runat="server">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <h3>Stored User Data</h3>
        <table id="userTable" border="2">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Mobile</th>
                    <th>Email</th>
                    <th>Gender</th>
                    <th>Hobbies</th>
                    <th>DOB</th>
                    <th>Options</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </form>

    <script src="script.js"></script>
</body>
</html>
