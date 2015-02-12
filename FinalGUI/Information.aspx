<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Information" %>

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
                <div  class="menuItem">
                    <a href="Home.aspx">Home</a>
                </div>
                <div class="menuItem" id="StuAccount1" runat="server">
                    <a href="#">My Account</a>
                </div>                    
                <div  class="menuItem">
                    <a href="Postings.aspx">Postings</a>
                </div>            
                <div class="menuItem">
                    <a href="#">Employers</a>
                </div>            
                <div class="menuItem" id="StuAccount2" runat="server">
                    <a href="MyAccount.aspx?email=">Upload Résumé</a>
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
               <div class="menuItem">
                    <a href="#">My Account</a>
                </div> 
               <div class="menuItem">
                    <a href="CreatePosting.aspx">Create Posting</a>
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
               <div class="menuItem">
                    <a href="#">My Account</a>
                </div> 
               <div class="menuItem">
                    <a href="Postings.aspx">Postings</a>
                </div>
            
                <div class="menuItem">
                    <a href="#">Employers</a>
                </div>
            
                <div class="menuItem">
                    <a href="CreatePosting.aspx">Create Posting</a>
                </div>
            
                <div class="menuItem">
                    <a href="#">Information</a>
                </div>
            
                <div class="menuItem">
                    <a href="LogOut.aspx">Log Out</a>
                </div>
            </div>
            <div class="content" runat="server">
                
                <a href="InfoDetails.aspx?form=NBCC_Visual_Identity_Standards_v1.pdf" runat="server" target="_blank">NBCC Visual Identity Standards</a><br />
                <a href="InfoDetails.aspx?form=2015_ITBA_Applied_Work_Experience_Handbook.pdf" runat="server" target="_blank">IT:Business Analyst Applied Work Experience Handbook</a><br />
                <a href="InfoDetails.aspx?form=2015_ITPA_Applied_Work_Experience_Handbook.pdf" runat="server" target="_blank">IT:Programmer Analyst Applied Work Experience Handbook</a><br />
                <a href="InfoDetails.aspx?form=academic-excellence.pdf" runat="server" target="_blank">Academic Excellence Policy</a><br />
                <a href="InfoDetails.aspx?form=academic-integrity.pdf" runat="server" target="_blank">Academic Integrity Policy</a><br />                
                <a href="InfoDetails.aspx?form=applied-workplace-experience.pdf" runat="server" target="_blank">Applied Workplace Experience Information</a><br />
                <a href="InfoDetails.aspx?form=certification-and-graduation.pdf" runat="server" target="_blank">Certification and Graduation Information</a><br />
                <a href="InfoDetails.aspx?form=student-code-of-conduct.pdf" onclick="OpenPDF" runat="server" target="_blank">NBCC Student Code of Conduct</a><br />
                
            </div>
            
        </form>
    </div>
    
</body>
</html>
