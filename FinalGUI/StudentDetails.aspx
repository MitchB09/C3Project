<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDetails.aspx.cs" Inherits="StudentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/Home.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="header">
            <img src="images/NBCCLogoSmall.png" alt="Alternate Text"/>
            <p>C3 Project</p>
        </div>
        <div id="StudentMenu" class="menu" runat="server">
            <div  class="menuItem">
                <a href="Home.aspx">Home</a>
            </div>                 
            <div class="menuItem" id="StuAccount1" runat="server">
                <a href="MyAccount.aspx?eMail=">My Account</a>
            </div>                    
            <div  class="menuItem">
                <a href="#">Postings</a>
            </div>            
            <div class="menuItem">
                <a href="#">Employers</a>
            </div>            
            <div class="menuItem" id="StuAccount2" runat="server">
                <a href="MyAccount.aspx?eMail=">Upload Résumé</a>
            </div>            
            <div class="menuItem">
                <a href="#">Information</a>
            </div>            
            <div class="menuItem">
                <a href="LogOut.aspx">Log Out</a>
            </div>
        </div>           
        <div id="EmployerMenu" class="menu" runat="server">
            <div  class="menuItem">
                <a href="Home.aspx">Home</a>
            </div>
            <div class="menuItem" id="EmpAccount" runat="server">
                <a href="#">My Account</a>
            </div> 
            <div class="menuItem">
                <a href="#">Create Posting</a>
            </div>
            
            <div class="menuItem">
                <a href="Students.aspx">Students</a>
            </div>
            
            <div class="menuItem">
                <a href="#">View Applications</a>
            </div>
            
            <div class="menuItem">
                <a href="#">Information</a>
            </div>
            
            <div class="menuItem">
                <a href="LogOut.aspx">Log Out</a>
            </div>
        </div>
        <div id="InstructorMenu" class="menu" runat="server">
            <div  class="menuItem">
                <a href="Home.aspx">Home</a>
            </div>
            <div class="menuItem" id="InsAccount" runat="server">
                <a href="#">My Account</a>
            </div> 
            <div class="menuItem">
                <a href="#">Postings</a>
            </div>
            
            <div class="menuItem">
                <a href="#">Employers</a>
            </div>
            
            <div class="menuItem">
                <a href="#">Upload Résumé</a>
            </div>
            
            <div class="menuItem">
                <a href="#">Information</a>
            </div>
            
            <div class="menuItem">
                <a href="LogOut.aspx">Log Out</a>
            </div>
        </div>
            
        <div  class="content">
            <div id="StudentStuff" runat="server">
                No Data
            </div>
            <div id="ResumeDiv" runat="server">
                <asp:Button runat="server" OnClick="Download" Text="Download Resume"/><span id="ResumeTitle" runat="server"></span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
