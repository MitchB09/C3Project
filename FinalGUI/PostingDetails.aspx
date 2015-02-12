<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostingDetails.aspx.cs" Inherits="PostingDetails" %>

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
                      
            <div id="Content" class="content" runat="server">
                <div id="PostDetails" runat="server">
                    No Data
                </div>
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <div id="EmailDiv" runat="server">
                    No Email
                </div>
                
            </div>
             
            
            
        </form>
    </div>
</body>
</html>