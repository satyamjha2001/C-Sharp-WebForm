<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormWithSQL.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function ValidateHobbies(source, args) {
            var checkboxes = document.querySelectorAll('input[type="checkbox"]');
            var checked = Array.from(checkboxes).some(cb => cb.checked);
            args.IsValid = checked;
        }
        document.addEventListener("DOMContentLoaded", function () {
            var dobInput = document.getElementById('<%= txtDOB.ClientID %>');
             var today = new Date().toISOString().split('T')[0]; // Get today's date in YYYY-MM-DD format

             // Disable future dates in datepicker
             dobInput.setAttribute("max", today);

             // Prevent manual entry of future dates
             dobInput.addEventListener("change", function () {
                 if (this.value > today) {
                     alert("Future dates are not allowed!");
                     this.value = ""; // Clear invalid input
                 }
             });
         });
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
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnShowData" Text="Show Data" runat="server" CausesValidation="false" OnClick="btnShowData_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <asp:GridView ID="FormGridView" AutoGenerateColumns="false" DataKeyNames="Id" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Hobbies" HeaderText="Hobbies" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" />
                <asp:BoundField DataField="Added_Date" HeaderText="Added_Date" />
                <asp:TemplateField HeaderText="Options">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" OnClick="OnClick_btnEdit" CausesValidation="false" runat="server">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" OnClick="OnClick_btnDelete" CausesValidation="false" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

