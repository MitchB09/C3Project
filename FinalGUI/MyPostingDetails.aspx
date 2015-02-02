<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyPostingDetails.aspx.cs" Inherits="MyPostingDetails" %>

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
                <div  class="menuItem">
                    <a href="Home.aspx">Home</a>
                </div>                 
                <div class="menuItem" id="StuAccount1" runat="server">
                    <a href="MyAccount.aspx?eMail=">My Account</a>
                </div>                    
                <div  class="menuItem">
                    <a href="Postings.aspx">Postings</a>
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
                      
            <div id="Content" class="content" runat="server">
                <div id="PostDetails" runat="server">
                    No Data
                </div>
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <br />
                <asp:Button runat="server" OnClick="EditPosting" Text="Edit Posting" />
                
            </div>
            <div id="EditContent" runat="server" class="content">
                <asp:Label runat="server" Text="Job Title: " CssClass="detailHeading" /><br />
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="details" />
                <br />
                <asp:Label runat="server" Text="Additional Details: " CssClass="detailHeading" /><br />
                <asp:TextBox ID="txtAdditionalDetails" runat="server" CssClass="details" TextMode="MultiLine" Columns="50" Rows="5" />
                <br />
                <asp:Button OnClick="UpdatePosting" runat="server" Text="Update" />
            </div> 
            
            
        </form>
    </div>
</body>
</html>