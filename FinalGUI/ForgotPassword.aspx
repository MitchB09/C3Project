<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/LogIn.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
</head>
<body>
    <div id="wrapper">
        <form id="ResetForm"
              name="frmLogIn"
              runat="server"
              >
            <img src="images/NBCCLogoSmall.png" alt="Alternate Text"/>
            <div id="ResetDetails">
                Enter your registered email below for a temporary password to be sent to you.
            </div>
            <br />
            <label for="txtUsername">email:</label>
            <br />
            <asp:Textbox ID='txtUsername' maxlength="50" runat="server"  />
            <br />
            
            
            <asp:Button runat="server" OnClick="SendEmail"/>
            <br />
            
            
        </form>
    </div>
</body>
</html>
