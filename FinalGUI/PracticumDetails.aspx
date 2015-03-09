<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PracticumDetails.aspx.cs" Inherits="PracticumDetails" %>

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
                <div id="PostDetails" runat="server">
                    No Data
                </div>
                <div id="EmployerDetails" runat="server">
                    No Data
                </div>
                <div id="EmailDiv" runat="server">
                    No Email
                </div>
                <div id="AdminControls" runat="server" visible="false">
                    <br /><br />
                    <asp:Button runat="server" ID="btnApprove" OnClick="ApprovePracticum" Text="Approve" />
                    <asp:Button runat="server" ID="btnOpenRemove" OnClick="StartRemovePosting" Text="Reject" />
                    <script>
                        function confirmation() {
                            if (confirm("Are you sure you want to delete?"))
                                return true;
                            else return false;
                        }

                    </script>
                    <div id="RemoveDetails" runat="server" visible="false">
                        <asp:Label Text="Reason:" CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox runat="server" ID="txtReason" CssClass="details" TextMode="MultiLine" Columns="50" Rows="5" /><br />
                        <asp:Button runat="server" ID="btnRemove" onClientClick="return confirmation();" OnClick="RejectPracticum" Text="Reject" />
                    </div>
                </div>
                
            </div>
             
            
            
        </form>
    </div>
</body>
</html>