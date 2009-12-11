<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SampleApplication.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        You are logged in as: <asp:Label ID="lblUserName" runat="server"></asp:Label>
        
        <asp:Button  ID="btnLogout" runat="server" Text="Logout" onclick="btnLogout_Click" /> 
    </div>
    </form>
</body>
</html>
