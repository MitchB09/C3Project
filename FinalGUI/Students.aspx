<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

            
            <div id="StudentContent"  class="content" runat="server">
                <div class="homeMenuOption">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">Go to Current Postings</a>
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
                <div class="homeMenuOption">
                    <a href="#">Upload new Resum&eacute;</a>
                    <br />
                    <small>Change your current resume</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div> 
            <!--
            <div id="EmployerContent" class="content" runat="server">
                <div class="homeMenuOption">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Student Profiles</a>
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
                <div class="homeMenuOption">
                    <a href="#">Upload new Posting</a>
                    <br />
                    <small>Change your current resume</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Practicum Information</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div>
            <div id="InstructorContent"  class="content" runat="server">
                <div class="homeMenuOption">
                    <a href="#">Go to My Account</a>
                    <br />
                    <small>View and make schanges to your account.</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">Go to Current Postings</a>
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
                    <a href="#">View Unvetted Employers</a>
                    <br />
                    <small>Change your current resume</small>
                </div>
                <hr />
                <div class="homeMenuOption">
                    <a href="#">View Pending Practicums</a>
                    <br />
                    <small>View general information about the practicums</small>
                </div>
            </div> 
            -->
            
        </form>
    </div>
</body>
</html>
