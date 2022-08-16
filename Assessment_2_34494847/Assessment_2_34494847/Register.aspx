<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Assessment_2_34494847._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: left;
            font-weight: bold;
            width: 125px;
        }
        .auto-style4 {
            text-align: right;
            font-weight: bold;
            width: 125px;
        }
    </style>
</head>
<body style="background-color: #00CCFF">
    <form id="form1" runat="server">
        <div>            
            <h1 class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Registration page" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
            </h1>
            <table align ="center">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label2" runat="server" Text="Username: " Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbUsername" runat="server" CssClass="auto-style1" Font-Names="Times New Roman"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server" Text="Password: " Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="auto-style1" Font-Names="Times New Roman"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
                    <td class="auto-style2">
                       <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" Font-Names="Times New Roman" /> 
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblError" runat="server" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
