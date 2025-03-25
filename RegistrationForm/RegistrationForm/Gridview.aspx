<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gridview.aspx.cs" Inherits="RegistrationForm.Gridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Registration form</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server">Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" placeholder="Enter your name"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server">Email:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server">Address:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter your address" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGender" runat="server">Gender:</asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="M" Text="Male" GroupName="Gender" runat="server" />
                    <asp:RadioButton ID="F" Text="Female" GroupName="Gender" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDOB" runat="server">DOB:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" placeholder="Enter your DOB"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCourse" runat="server">Course:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="CourseDropDown" runat="server">
                        <asp:ListItem>Select your Course</asp:ListItem>
                        <asp:ListItem Value="BCA">BCA</asp:ListItem>
                        <asp:ListItem Value="MCA">MCA</asp:ListItem>
                        <asp:ListItem Value="B.Tech">B.Tech</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server">Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblShift" runat="server">Shift:</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="Morning" Text="Morning" runat="server" />
                    <asp:CheckBox ID="Noon" Text="Noon" runat="server" />
                    <asp:CheckBox ID="Evening" Text="Evening" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server" />
                    <asp:Button ID="Reset" Text="Reset" OnClick="Reset_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <%--<asp:GridView ID="RegistrationGridView"  runat="server"></asp:GridView>--%>

        <asp:GridView ID="RegistrationGridView" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
                <asp:BoundField DataField="Email" HeaderText="Email"/>
                <asp:BoundField DataField="Address" HeaderText="Address"/>
                <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                <asp:BoundField DataField="DOB" HeaderText="DOB"/>
                <asp:BoundField DataField="Course" HeaderText="Course"/>
                <asp:BoundField DataField="PassWord" HeaderText="PassWord"/>
                <asp:BoundField DataField="Shift" HeaderText="Shift"/>
                <asp:TemplateField HeaderText="Options">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" OnClick="OnClick_btnEdit" runat="server">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" OnClick="OnClick_btnDelete" runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
</form>
</body>
</html>
