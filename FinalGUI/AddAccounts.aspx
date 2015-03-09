<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAccounts.aspx.cs" Inherits="TestingExcel" %>

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
            <div id="AdminMenu" class="menu" runat="server">

            </div>
                      
            <div id="Content" class="content" runat="server">
                <span class="postTitle">Add Student by Excel</span>
                <br />
                <asp:FileUpload  ID="fulStudentUpload" runat="server" />
                <asp:Button Text="Add Students" onClick="AddStudents" runat="server" />
                <br />
                <br />
                <span class="postTitle">Add Instructor by Excel</span>
                <br />
                <asp:FileUpload  ID="fulInstructorUpload" runat="server" />
                <asp:Button Text="Add Instructors" onClick="AddInstructors" runat="server" />
            </div>
             
            
            
        </form>
    </div>
</body>
</html>