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
                
            </div>           
            <div id="EmployerMenu" class="menu" runat="server">
               
            </div>
            <div id="InstructorMenu" class="menu" runat="server">
               
            </div>
            <div id="AdminMenu" class="menu" runat="server">

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
                <div class="homeMenuOption" id="StuAccount4" runat="server">
                    <a href="MyAccount.aspx">Upload new Résumé</a>
                    <br />
                    <small>Change your current résumé</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="Information.aspx">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div> 
            <div id="EmployerContent" class="content" runat="server">                
                <div class="homeMenuOption">
                    <a href="Students.aspx">View Student Profiles</a>
                    <br />
                    <small>Check out all current available posings</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="MyPostings.aspx">View My Postings</a>
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
                <div class="homeMenuOption" id="EmpAccount2" runat="server">
                    <a href="UpdatePassword.aspx">Update Password</a>
                    <br />
                    <small>Change your current password.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="Information.aspx">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div>
            <div id="InstructorContent"  class="content" runat="server">                 
                <div class="homeMenuOption">
                    <a href="Postings.aspx">Go to Current Postings</a>
                    <br />
                    <small>Check out all current available posings</small>
                </div>
                <hr />                
                <div class="homeMenuOption">
                    <a href="UnvettedEmployers.aspx">View Unvetted Employers</a>
                    <br />
                    <small>View and judge unapproved employers</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="BrowsePracticums.aspx">View Pending Practicums</a>
                    <br />
                    <small>Browse practicums pending approval</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="UpdatePassword.aspx">Update Password</a>
                    <br />
                    <small>Update your current password.</small>
                </div>
            </div> 
            <div id="AdminContent" runat="server" class="content">
                <div class="homeMenuOption">
                    <a href="AddAccounts.aspx">Add Accounts</a>
                    <br />
                    <small>Add Student or Instructor Accounts.</small>
                </div>
            </div>
           
            
        </form>
    </div>
    
</body>
</html>
