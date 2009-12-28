<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SampleApplication.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home</title>

    <script src="js/Frameworks/jquery-1.3.1.js" type="text/javascript"></script>
    <script src="js/Frameworks/service-proxy.js" type="text/javascript"></script>
    <script src="js/Frameworks/JsInject.js" type="text/javascript"></script>
    <script src="js/Frameworks/json2.js" type="text/javascript"></script>
    <script src="js/Frameworks/jquery-jtemplates.js" type="text/javascript"></script>
    
    <script src="js/Ignitions/HomeIgnition.js" type="text/javascript"></script>
    <script src="js/Mediators/HomeMediator.js" type="text/javascript"></script>
    <script src="js/Services/Services.js" type="text/javascript"></script>

    <script src="js/Widgets/UserNameWidget.js" type="text/javascript"></script>
    <script src="js/Widgets/UserListWidget.js" type="text/javascript"></script>
    <script src="js/Widgets/AddUserWidget.js" type="text/javascript"></script>
    <script src="js/Widgets/AjaxErrorWidget.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function()
        {
            new HomeIgnition().CreateAndRun();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnBaseUrl" runat="server" />
    <div>
        You are logged in as: <span ID="lblUserName"></span>
        
        <asp:Button  ID="btnLogout" runat="server" Text="Logout" onclick="btnLogout_Click" /> 
        
        <textarea id="templateUsers" style="display:none">
            {#template MAIN}
                <table style="border:1px solid black">
                    {#foreach $T as u}
                    <tr >
                        <td style="border:1px solid black">{$T.u.Name}</td>
                        <td style="border:1px solid black">{$T.u.Password}</td>
                    </tr>
                    {#/for}
                </table>
            {#/template MAIN}
        </textarea>
        
        <br />
        <br />
        <table style="border:1px solid black">
            <tr>
                <td colspan="2" style="background-color:lightblue;">Add user:</td>
            </tr>
             <tr>
                <td colspan="2"><span id="lblError"></span></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><input type="text" id="txtName" /></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><input type="text" id="txtPassword" /></td>
            </tr>
            <tr>
                <td colspan="2"> <input type="button" id="btnAddUser" Value="Add" /></td>
            </tr>
        </table>
        <br/>
        <br/>
        <br/>
        List Of Users:
        <div id="holderUsers"></div>
    </div>
    
    <div style="position:absolute;left:300px;top:10px;border:solid 1px red">
        <span id="lblAjaxErrorMessage"></span>
    </div>
    </form>
</body>
</html>
