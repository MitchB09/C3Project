<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="UpdatePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/Home.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
</head>
<body>
    <div id="wrapper">
        <div id="header">
            <img src="images/NBCCLogoSmall.png" alt="Alternate Text"/>
            <p>C3 Project</p>
        </div>
        <form id="MenuForm"
              name="frmLogIn"
              runat="server"
              >
            <div id="StudentMenu" class="menu" runat="server">
                
            </div>           
            <div id="EmployerMenu" class="menu" runat="server">
               
            </div>
            <div id="InstructorMenu" class="menu" runat="server">
               
            </div>
            <div class="content" runat="server">
                <asp:Label Text="Old Password" runat="server" CssClass="detailHeading" /><br />
                <asp:TextBox TextMode="Password" ID="psdOldPassword" runat="server" CssClass="details" />
                <asp:RequiredFieldValidator ControlToValidate="psdOldPassword" Text="*" ErrorMessage="Old Password is Required" Display="Dynamic" runat="server"/>
                <br />                
                <asp:Label Text="New Password" runat="server" CssClass="detailHeading" /><br />
                <asp:TextBox TextMode="Password" ID="psdNewPassword" runat="server" CssClass="details" />
                <asp:RequiredFieldValidator ControlToValidate="psdNewPassword" Text="*" ErrorMessage="New Password is Required" Display="Dynamic" runat="server"/>
                <br />                
                <asp:Label Text="Confirm New Password" runat="server" CssClass="detailHeading" /><br />
                <asp:TextBox TextMode="Password" ID="psdConfirmNewPasswd" runat="server" CssClass="details" />
                <asp:RequiredFieldValidator ControlToValidate="psdConfirmNewPasswd" Text="*" ErrorMessage="Password Must be Confirmed" Display="Dynamic" runat="server"/>
                <asp:CompareValidator ControlToValidate="psdConfirmNewPasswd" ControlToCompare="psdNewPassword" Operator="Equal" Text="*" ErrorMessage="Passwords Must Match" Display="Dynamic" runat="server" />
                <br />
                <br />
                <asp:ValidationSummary id="valSum" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                
                <asp:Button Text="Update Password" runat="server" OnClick="Update" />
            </div>
            
        </form>
    </div>
    
</body>
</html>
