<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Project2.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 243px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblheading" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="PICTURE UPLOAD"></asp:Label>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Blue" NavigateUrl="~/Main.aspx">Main Menu</asp:HyperLink>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="True" Font-Size="Medium" />
        <p>
            <asp:Button ID="BtnUplaod" runat="server" OnClick="Button1_Click" Text="Upload" Width="100px" />
        </p>
        <p>
            <asp:Label ID="lblDisplay" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </p>
        <p>
            <asp:RadioButton ID="radShare" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Sharable" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Share" Visible="False" />
&nbsp;<asp:RadioButton ID="radPvt" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" GroupName="Sharable" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Private" Visible="False" />
        </p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblGeo" runat="server" Font-Bold="True" Font-Size="Medium" Text="Geo Location:" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server" Font-Size="Medium" MaxLength="20" Visible="False" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTag" runat="server" Font-Bold="True" Font-Size="Medium" Text="Tags:" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTag" runat="server" Font-Size="Medium" MaxLength="50" Visible="False" Width="150px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </p>
        <asp:GridView ID="myGrid" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Caption="Select a person to share" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
        <br />
        <asp:Button ID="btnShare" runat="server" Text="Share" Width="100px" OnClick="btnShare_Click"/>
    </form>
</body>
</html>
