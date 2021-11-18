<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Project2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            font-size: larger;
        }
    </style>
</head>
<body style="height: 463px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="auto-style1">
                <asp:Label ID="lblHeading" runat="server" CssClass="auto-style3" Font-Bold="True" Font-Size="XX-Large" Text="Welcome"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <asp:Label ID="lblUn" runat="server" Font-Bold="True" Font-Size="Medium" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUn" runat="server" Font-Size="Medium" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUn" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <p>
                <asp:Label ID="lblPw" runat="server" Font-Bold="True" Font-Size="Medium" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPw" runat="server" Font-Size="Large" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPw" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </p>
            <asp:Button ID="btnLogin" runat="server" Text="Login" />
            <br />
            <br />
            <br />
            <br />
            <p class="auto-style2">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Forget.aspx">Forgot Password?</asp:HyperLink>
            </p>
            <div class="auto-style2">
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue">Sign Up</asp:HyperLink>
            </div>
        </div>
    </form>
    </body>
</html>
