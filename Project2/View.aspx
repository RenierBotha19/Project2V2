<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Project2.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 229px;
            height: 135px;
        }
        .auto-style3 {
            width: 104px;
        }
        .auto-style4 {
            width: 20%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="MY PICTURES"></asp:Label>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue" NavigateUrl="~/Main.aspx">Main Menu</asp:HyperLink>
        <br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField></asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <img alt="" class="auto-style2" src="" /><asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="auto-style2" Font-Bold="True" Font-Size="Medium">
            <asp:ListItem>Edit Details</asp:ListItem>
            <asp:ListItem>Share Picture</asp:ListItem>
        </asp:RadioButtonList>
        <table class="auto-style4">
            <tr>
                <td class="auto-style3">
                        <asp:Label ID="lblGeo" runat="server" Font-Bold="True" Font-Size="Medium" Text="Geo Location:" Visible="False"></asp:Label>
                    </td>
                <td>
                        <asp:TextBox ID="txtLocation" runat="server" Font-Size="Medium" MaxLength="20" Visible="False" Width="150px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">
                        <asp:Label ID="lblTag" runat="server" Font-Bold="True" Font-Size="Medium" Text="Tags:" Visible="False"></asp:Label>
                    </td>
                <td>
                        <asp:TextBox ID="txtTag" runat="server" Font-Size="Medium" MaxLength="50" Visible="False" Width="150px"></asp:TextBox>
                    </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnproceed" runat="server" Text="Proceed" Width="100px" />
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
