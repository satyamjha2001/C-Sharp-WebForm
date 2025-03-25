<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegistrationForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <link href="CSS\style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Registration form</h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Name" runat="server">Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" placeholder="Enter your name"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Email" runat="server">Email:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Enter your email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Address" runat="server">Address:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="AddressTextBox" runat="server" placeholder="Enter your address" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Gender" runat="server">Gender:</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="M" Text="Male" GroupName="Gender" runat="server" />
                        <asp:RadioButton ID="F" Text="Female" GroupName="Gender" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="DOB" runat="server">DOB:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="DOBTextBox" runat="server" TextMode="Date" placeholder="Enter your DOB"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Course" runat="server">Course:</asp:Label>
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
                        <asp:Label ID="Password" runat="server">Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Shift" runat="server">Shift:</asp:Label>
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
    </form>
    <p>
        <asp:Label ID="NameValue" runat="server"></asp:Label><br />
        <asp:Label ID="EmailValue" runat="server"></asp:Label><br />
        <asp:Label ID="AddressValue" runat="server"></asp:Label><br />
        <asp:Label ID="GenderValue" runat="server"></asp:Label><br />
        <asp:Label ID="DOBValue" runat="server"></asp:Label><br />
        <asp:Label ID="CourseValue" runat="server"></asp:Label><br />
        <asp:Label ID="PasswordValue" runat="server"></asp:Label><br />
        <asp:Label ID="ShiftValue" runat="server"></asp:Label>
    </p>
</body>
</html>
