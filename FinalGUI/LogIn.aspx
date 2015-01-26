<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/LogIn.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
</head>
<body>
    <div id="wrapper">
        <form id="LogInForm"
              name="frmLogIn"
              runat="server"
              >
            <img src="images/NBCCLogoSmall.png" alt="Alternate Text"/>
            <label for="txtUsername">Username:</label>
            <br />
            <asp:Textbox ID='username' maxlength="50" runat="server"  />
            <br />
            <br />
            <label for="psdPassword">Password:</label>
            <br />
            <asp:Textbox TextMode="password" ID="password" maxlength="36" runat="server" />
            <br />
            <asp:Button runat="server" OnClick="LogIn"/>
            <br />
            <div id="LoginOptions">
                <a href="#">Forgot Password</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="CreateEmployerAccount.aspx">Create Account</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="#">More Information</a>
            </div>
            
        </form>
    </div>
</body>
</html>
