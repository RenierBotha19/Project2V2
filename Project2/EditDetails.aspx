<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDetails.aspx.cs" Inherits="Project2.EditDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="EDIT YOUR DETAILS"></asp:Label>
        </div>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Main.aspx">Main Menu</asp:HyperLink>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:RadioButton ID="radEmail" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Decision" OnCheckedChanged="radEmail_CheckedChanged" Text="Email" />
&nbsp;
            <asp:RadioButton ID="RadCell" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Decision" OnCheckedChanged="radEmail_CheckedChanged" Text="Cellphone Number" />
&nbsp;
            <asp:RadioButton ID="radPassword" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Decision" OnCheckedChanged="radEmail_CheckedChanged" Text="Password" />
        </p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblEnter" runat="server" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtEnter" runat="server" Font-Bold="False" Font-Size="Medium" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEnter" Enabled="False" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="False">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEnter" Enabled="False" ErrorMessage="RegularExpressionValidator" Font-Bold="True" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="False">Please enter a valid email</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblConfirm" runat="server" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtConf" runat="server" Font-Bold="False" Font-Size="Medium" Visible="False"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtEnter" ControlToValidate="txtConf" Enabled="False" ErrorMessage="CompareValidator" Font-Bold="True" ForeColor="Red" Visible="False">Entered data does not match</asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </p>
        <p>
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Details" Visible="False" Width="150px" />
        </p>
        <p>
            <asp:Label ID="lblDisplay" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
