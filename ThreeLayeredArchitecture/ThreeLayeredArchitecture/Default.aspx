<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ThreeLayeredArchitecture.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Three Tier Architecture</h1>
            <table>
                <tr>
                    <th colspan="2">
                        <asp:Label ID="lblMsg" runat="server" />
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server">Student Name</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" placeholder="Enter Your Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valName" ErrorMessage="*" SetFocusOnError="true" ControlToValidate="txtName" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server">Email</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" TextMode="Email" placeholder="Enter your email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valEmail" ErrorMessage="*" ControlToValidate="txtEmail" SetFocusOnError="true" ForeColor="Red" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegValEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email" SetFocusOnError="true" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFees" AssociatedControlID="txtFees" runat="server">Fees</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFees" TextMode="Number" placeholder="Enter your fees" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valFees" ErrorMessage="*" ControlToValidate="txtFees" ForeColor="Red" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCourse" runat="server">Course</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="valddlCourse" ErrorMessage="*" ControlToValidate="ddlCourse" InitialValue="" ForeColor="Red" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grdStudent" AutoGenerateColumns="false" DataKeyNames="SId" runat="server">
            <Columns>
                <asp:BoundField DataField="sId" HeaderText="SId" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Fee" HeaderText="Fees" />
                <asp:BoundField DataField="CourseName" HeaderText="Course" />
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
