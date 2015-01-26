<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePosting.aspx.cs" Inherits="CreatePosting" %>

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
                <asp:Label CssClass="detailHeading" runat="server" Text="Company: " /><br />
                <asp:TextBox CssClass="details" ID="CompanyName" runat="server" />
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Cotact: " /><br />
                <asp:TextBox CssClass="details" ID="ContactName" runat="server" />
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="eMail: " /><br />
                <asp:TextBox CssClass="details" ID="ContactEMail" runat="server" />
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Job Title: " /><br />
                <asp:TextBox CssClass="details" ID="JobTitle" runat="server" />
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Additional Details: " /><br />
                <asp:TextBox  CssClass="details" TextMode="MultiLine" Columns="50" Rows="5" ID="AddDetails" runat="server" />
                <br />
                <asp:Button runat="server" OnClick="SubmitPosting" Text="Submit Posting" />
            </div>
             
            
            
        </form>
    </div>
</body>
</html>