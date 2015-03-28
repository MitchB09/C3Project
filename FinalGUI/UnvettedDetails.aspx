<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnvettedDetails.aspx.cs" Inherits="UnvettedDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/Home.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
    
<script>
    function confirmation(action) {
        if (confirm("Are you sure you want to " + action + " employer?"))
            return true;
        else return false;
    }
</script>
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
               
            </div>
                      
            <div id="Content" class="content" runat="server">
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <div id="InstructorControls" runat="server">
                    <asp:Button onClientClick="return confirmation('approve');" OnClick="Approve" Text="Approve" runat="server"/>
                    <asp:Button onClientClick="return confirmation('remove');" OnClick="Reject" Text="Reject" runat="server"/>
                </div>
                
            </div>
             
            
            
        </form>
    </div>
</body>
</html>