<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyPostingDetails.aspx.cs" Inherits="MyPostingDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C3 Project</title>
    <link rel="stylesheet" href="CSS/Home.css" type="text/css" />
    <link rel="icon" href="images/favicon.ico" />
    
<script>
    function confirmation() {
        if (confirm("Are you sure you want to remove posting?"))
            return true;
        else
            return false;
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
            <div id="StudentMenu" class="menu" runat="server">
                
            </div>           
            <div id="EmployerMenu" class="menu" runat="server">
               
            </div>
            <div id="InstructorMenu" class="menu" runat="server">
               
            </div>
            <div id="AdminMenu" class="menu" runat="server">
               
            </div>
                      
            <div id="Content" class="content" runat="server">
                <div id="PostDetails" runat="server">
                    No Data
                </div>
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <br />
                <asp:Button runat="server" OnClick="EditPosting" Text="Edit Posting" />&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" OnClientClick="return confirmation();" OnClick="RemovePosting" Text="RemovePosting" />

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