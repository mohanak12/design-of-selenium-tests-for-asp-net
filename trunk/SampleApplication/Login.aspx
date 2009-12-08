<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SampleApplication._Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" /></td>
                
            </tr>
            <tr>
                <td>User:</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"/></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"/></td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnLogin" runat="server" Text="Log Me In" 
                        onclick="btnLogin_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
