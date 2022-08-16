<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assessment_2_34494847.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            width: 125px;
            text-align: left;
        }
        .auto-style5 {
            font-weight: bold;
        }
        .auto-style6 {
            width: 125px;
            text-align: right;
            height: 25px;
        }
        .auto-style7 {
            height: 25px;
        }
        .auto-style8 {
            width: 125px;
            text-align: right;
        }
        .auto-style9 {
            text-align: left;
        }
        </style>
</head>
<body style="background-color: #00CCFF">
    <form id="form1" runat="server" >
        <div>
            <h1 class="auto-style3">
                <asp:Label ID="Label1" runat="server" Text="Welcome to login screen" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
            </h1>
            <table align = "center">
                <tr>
                    <td class="auto-style8">                  
                        <strong>                   
                        <asp:Label ID="Label2" runat="server" Text="Username: " Font-Names="Times New Roman" ForeColor="White"></asp:Label>               
                        </strong>    
                    </td>
                    <td>
                        <strong>
                        <asp:TextBox ID="tbUsername" runat="server" Width="100px" CssClass="auto-style5" Font-Names="Times New Roman"></asp:TextBox>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <strong>
                        <asp:Label ID="Label3" runat="server" Text="Password: " Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style7">
                        <strong>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="100px" CssClass="auto-style5" Font-Names="Times New Roman"></asp:TextBox>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <strong>
                        <asp:CheckBox ID="cbRem" runat="server" Text="Remember me" Font-Names="Times New Roman" ForeColor="White" />
                        </strong>
                    </td>
                    <td class="auto-style3">
                        <strong>
                        <asp:Button ID="btnLog" runat="server" OnClick="btnLog_Click" Text="Login" Font-Names="Times New Roman" />
                        </strong>
                    </td>
                    <td class="auto-style9">
                        <strong>
                        <asp:Label ID="lblError" runat="server" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                        </strong>
                    </td>
                </tr>
            </table>
            <p class="auto-style3">
                <strong>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx" Font-Names="Times New Roman" ForeColor="White">Click here to register...</asp:HyperLink>
                </strong>
            </p>
        </div>
    </form>
</body>
</html>
