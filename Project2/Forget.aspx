<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="Project2.Forget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            width: 454px;
            font-size: medium;
        }
        .auto-style18 {
            width: 150px;
        }
        .auto-style20 {
            width: 151px;
        }
        .auto-style23 {
            height: 23px;
            width: 226px;
            text-align: left;
        }
        .auto-style24 {
            height: 26px;
            text-align: center;
        }
        .auto-style25 {
            height: 23px;
            width: 226px;
            text-align: right;
        }
        .auto-style26 {
            width: 450px;
            font-size: medium;
        }
        .auto-style27 {
            width: 151px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>
            <asp:Label ID="lblForget" runat="server" CssClass="auto-style2" Text="FORGOT PASSWORD?"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            </strong>
        </div>
        <table align="center" class="auto-style26">
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name:"></asp:Label>
                </td>
                <td class="auto-style27">
                    <asp:TextBox ID="txtName" runat="server" Font-Size="Medium" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="3"></td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblSurname" runat="server" Font-Bold="True" Font-Size="Medium" Text="Surname:"></asp:Label>
                </td>
                <td class="auto-style27">
                    <asp:TextBox ID="txtSurname" runat="server" Font-Size="Medium" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSurname" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="3"></td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Size="Medium" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style27">
                    <asp:TextBox ID="txtEmail" runat="server" Font-Size="Medium" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblCell" runat="server" Font-Bold="True" Font-Size="Medium" Text="Cell No:"></asp:Label>
                </td>
                <td class="auto-style27">
                    <asp:TextBox ID="txtCell" runat="server" Font-Size="Medium" Width="180px" MaxLength="10" TextMode="Phone"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCell" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="3"></td>
            </tr>
        </table>
        <p>
        </p>
        <table align="center" class="auto-style10">
            <tr>
                <td class="auto-style25">
                    <asp:Button ID="btnRecover" runat="server" Text="Recover" Width="100px" OnClick="btnRecover_Click" />
                </td>
                <td class="auto-style23">
                    <asp:Button ID="btnHome" runat="server" Enabled="False" Text="Home" Width="100px" OnClick="btnHome_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24" colspan="2">
                    <asp:Label ID="lblWrong" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
