<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnvettedDetails.aspx.cs" Inherits="UnvettedDetails" %>

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
                      
            <div id="Content" class="content" runat="server">
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <div id="InstructorControls" runat="server">
                    <asp:Button OnClick="Approve" Text="Approve" runat="server"/>
                    <asp:Button OnClick="Reject" Text="Reject" runat="server"/>
                </div>
                
            </div>
             
            
            
        </form>
    </div>
</body>
</html>