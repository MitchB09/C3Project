<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="HomeStudent" %>


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
                <div class="menuItem" id="StuAccount" runat="server">
                    <a href="MyAccount.aspx?eMail=">My Account</a>
                </div>                    
                <div  class="menuItem">
                    <a href="Postings.aspx">Postings</a>
                </div>            
                <div class="menuItem">
                    <a href="#">Employers</a>
                </div>            
                <div class="menuItem" id="StuAccount3" runat="server">
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
                    <a href="MyPostings.aspx">My Postings</a>
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
               <div class="menuItem" id="InsAccount" runat="server">
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

            <div id="StudentContent"  class="content" runat="server">
                <div class="homeMenuOption" id="StuAccount2" runat="server">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="Postings.aspx">Go to Current Postings</a>
                    <br />
                    <small>Check out all current available posings</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View List of Potential Employers</a>
                    <br />
                    <small>Check the list of potential employers in the province</small>
                </div>
                <hr />
                <div class="homeMenuOption" id="StuAccount4" runat="server">
                    <a href="MyAccount.aspx">Upload new Résumé</a>
                    <br />
                    <small>Change your current résumé</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div> 
            <div id="EmployerContent" class="content" runat="server">
                <div class="homeMenuOption" id="EmpAccount2" runat="server">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="Students.aspx">View Student Profiles</a>
                    <br />
                    <small>Check out all current available posings</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View My Postings</a>
                    <br />
                    <small>Check the list of potential employers in the province</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="CreatePosting.aspx">Upload new Posting</a>
                    <br />
                    <small>Change your current résumé</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div>
            <div id="InstructorContent"  class="content" runat="server">
                <div class="homeMenuOption" id="InsAccount2" runat="server">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="Postings.aspx">Go to Current Postings</a>
                    <br />
                    <small>Check out all current available posings</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">Edit List of Potential Employers</a>
                    <br />
                    <small>Check the list of potential employers in the province</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="UnvettedEmployers.aspx">View Unvetted Employers</a>
                    <br />
                    <small>Change your current résumé</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Pending Practicums</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div> 
           
            
        </form>
    </div>
    
</body>
</html>
