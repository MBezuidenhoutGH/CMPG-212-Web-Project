<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Workshop.aspx.cs" Inherits="Assessment_2_34494847.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 114px;
            text-align: left;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 79px;
            height: 29px;
        }
        .auto-style5 {
            width: 127px;
            text-align: center;
            height: 29px;
        }
        .auto-style6 {
            width: 125px;
            text-align: left;
            height: 29px;
        }
    </style>
</head>
<body style="background-color: #00CCFF">
    <form id="form1" runat="server">
        <div class="auto-style2">
            <h1 class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Welcome USERNAME!" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
            </h1>
            <div class="auto-style2">
                <strong>
            <asp:Label ID="Label2" runat="server" Text="Please indicate your preferred date for a programming workshop below." Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                </strong>
                <br />
                <strong>
            <asp:Label ID="Label3" runat="server" Text="Here is your current date and selected programming language (if any):" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                <br />
                </strong>
            <br />
                <strong>
            </div>
            <asp:GridView ID="gvData" runat="server" Font-Names="Times New Roman" ForeColor="White" align ="center">
            </asp:GridView>
            <div class="auto-style2">
                </strong>
            <br />
                <strong>
            <asp:Label ID="Label4" runat="server" Text="To indicate a new preferred date, choose one on the calendar below:" Font-Names="Times New Roman" ForeColor="White"></asp:Label>
                </strong>
            <br />
            <br />

            </div>

            <table align ="center">
                <tr>
                    <td>
                        <strong>
                        <asp:Calendar ID="calPref" runat="server" Font-Names="Times New Roman" ForeColor="White"></asp:Calendar>
                        </strong>
                    </td>

                    <td class="auto-style1">

                        <strong>

                        <asp:RadioButton ID="rbJava" runat="server" AutoPostBack="True" GroupName="ProgLangs" OnCheckedChanged="rbJava_CheckedChanged" Text="Java" Font-Names="Times New Roman" ForeColor="White" />
                        </strong>
                        <br />
                        <br />
                        <strong>
                        <asp:RadioButton ID="rbCSharp" runat="server" AutoPostBack="True" GroupName="ProgLangs" OnCheckedChanged="rbJava_CheckedChanged" Text="C#" Font-Names="Times New Roman" ForeColor="White" />
                        </strong>
                        <br />
                        <br />
                        <strong>
                        <asp:RadioButton ID="rbCPP" runat="server" AutoPostBack="True" GroupName="ProgLangs" OnCheckedChanged="rbJava_CheckedChanged" Text="C++" Font-Names="Times New Roman" ForeColor="White" />

                        </strong>

                    </td>
                </tr>
            </table>
        </div>
        <div class="auto-style2">
        <br />
            <table align ="center">
                <tr>
                    <td class="auto-style6">
                        <asp:Button ID="btnCon" runat="server" OnClick="btnCon_Click" Text="Confirm date" Font-Names="Times New Roman" Width="90px" />
                    </td>
                    <td class="auto-style3">

                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnLogout" runat="server" OnClick="Button1_Click" Text="Logout" Font-Names="Times New Roman" Width="90px" />
                    </td>
                </tr>
            </table>   
        </div>
    </form>
</body>
</html>
