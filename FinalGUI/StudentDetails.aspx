<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDetails.aspx.cs" Inherits="StudentDetails" %>

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
        <form id="form1" runat="server">
        <div id="StudentMenu" class="menu" runat="server">
            
        </div>           
        <div id="EmployerMenu" class="menu" runat="server">
            
        </div>
        <div id="InstructorMenu" class="menu" runat="server">
            
        </div>
            
        <div  class="content">
            <div id="StudentStuff" runat="server">
                No Data
            </div>
            <div id="ResumeDiv" runat="server">
                <asp:Button runat="server" OnClick="Download" Text="Download Resume"/><span id="ResumeTitle" runat="server"></span>
            </div>
            <div id="StudentEmail" runat="server">
                
            </div>
        </div>
        </form>
    </div>
    
</body>
</html>
