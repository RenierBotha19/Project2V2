<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Project2.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-align: left;
        }
        .auto-style7 {
            width: 149px;
            text-align: left;
        }
        .auto-style10 {
            width: 586px;
        }
        .auto-style12 {
            width: 292px;
            text-align: left;
        }
        .auto-style13 {
            width: 100px;
            text-align: left;
        }
        .auto-style14 {
            height: 23px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
        <div class="auto-style5">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="REGISTER"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtName" runat="server" Font-Size="Medium" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblSurname" runat="server" Font-Bold="True" Font-Size="Medium" Text="Surname:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtSurname" runat="server" Font-Size="Medium" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSurname" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Size="Medium" Text="Email:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtEmail" runat="server" Font-Size="Medium" TextMode="Email" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" Font-Bold="True" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Incorrect Format</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblCell" runat="server" Font-Bold="True" Font-Size="Medium" Text="Cell Nr:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtCell" runat="server" Font-Size="Medium" MaxLength="10" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCell" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="Medium" Text="ID Number:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtID" runat="server" Font-Size="Medium" MaxLength="13" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtID" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblPW" runat="server" Font-Bold="True" Font-Size="Medium" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtPassword" runat="server" Font-Size="Medium" TextMode="Password" Width="180px" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblConfirm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtCon" runat="server" Font-Size="Medium" TextMode="Password" Width="180px"></asp:TextBox>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCon" ErrorMessage="CompareValidator" Font-Bold="True" Font-Size="Medium" ForeColor="Red">Passwords doesn&#39;t match</asp:CompareValidator>
                    </td>
                </tr>
            </table>
            <p>
            </p>
            <table align="center" class="auto-style10">
                <tr>
                    <td class="auto-style13">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" Width="100px" OnClick="btnRegister_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:HyperLink ID="HyperLink1" runat="server" Enabled="False" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Main.aspx" Visible="False">Proceed</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lblDisplay" runat="server" Font-Size="Large"></asp:Label>
        </div>
    </form>
</body>
</html>
