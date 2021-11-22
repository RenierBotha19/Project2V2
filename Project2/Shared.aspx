<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shared.aspx.cs" Inherits="Project2.Shared" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style4 {
            width: 20%;
        }
        .auto-style3 {
            width: 104px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="SHARED WITH ME"></asp:Label>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue" NavigateUrl="~/Main.aspx">Main Menu</asp:HyperLink>
        <br />
        <br />
        <asp:GridView ID="myGrid" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="Medium" Text="Please enter PictureID:"></asp:Label>
        <asp:TextBox ID="txtID" runat="server" Font-Size="Medium" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSelect" runat="server" Text="Select" Width="100px" OnClick="btnSelect_Click" />
        <br />
        <br />
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
        <asp:Label ID="lblDisplay" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnproceed" runat="server" Text="Proceed" Visible="False" Width="100px" OnClick="btnproceed_Click" />
        <br />
        <br />
            <asp:Image ID="Image1" runat="server" Visible="False" />
    </form>
</body>
</html>
