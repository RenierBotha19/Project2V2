<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Project2.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 990px;
            height: 142px;
        }
        .auto-style4 {
            text-align: left;
            height: 47px;
            width: 329px;
        }
        .auto-style28 {
            height: 48px;
            width: 329px;
            text-align: left;
        }
        .auto-style30 {
            width: 330px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <table align="center" class="auto-style2">
            <tr>
                <td class="auto-style4">
                    <asp:RadioButton ID="radEdit" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Main" OnCheckedChanged="radEdit_CheckedChanged" Text="Edit Profile" />
                </td>
                <td class="auto-style4">
                    <asp:RadioButton ID="radView" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Main" OnCheckedChanged="radEdit_CheckedChanged" Text="View Uploads" />
                </td>
                <td class="auto-style30" rowspan="2">
                    <asp:RadioButton ID="radLogout" runat="server" AutoPostBack="True" Font-Bold="True" Font-Italic="True" Font-Size="Medium" GroupName="Main" OnCheckedChanged="radEdit_CheckedChanged" Text="Logout" />
                </td>
            </tr>
            <tr>
                <td class="auto-style28">
                    <asp:RadioButton ID="radUpload" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Main" OnCheckedChanged="radEdit_CheckedChanged" Text="Upload Picture" />
                </td>
                <td class="auto-style28">
                    <asp:RadioButton ID="radShare" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Main" OnCheckedChanged="radEdit_CheckedChanged" Text="Shared Pictures" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
