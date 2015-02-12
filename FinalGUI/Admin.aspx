<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

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
            <div id="AdminMenu" class="menu" runat="server">
                
            </div>            

            <div id="AdminContent"  class="content" runat="server">
                Add Student(form) Add Student(s) (Excel Document) <br />
                Add Instructor(form) Add Instructor(s) (Excel Document) <br />
                Add Employer(form) Add Employers(s) (Excel Document) <br />
            </div> 
                       
            
        </form>
    </div>
    
</body>
</html>