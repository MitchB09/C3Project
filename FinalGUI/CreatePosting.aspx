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
                
            </div>           
            <div id="EmployerMenu" class="menu" runat="server">
               
            </div>
            <div id="InstructorMenu" class="menu" runat="server">
               
            </div>
                      
            <div id="Content" class="content" runat="server">
                <asp:Label CssClass="detailHeading" runat="server" Text="Company: " /><br />
                <asp:TextBox CssClass="details" ID="CompanyName" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="ContactName" Text="*" ErrorMessage="Company Name is Required" Display="Dynamic" runat="server"/>
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Contact: " /><br />
                <asp:TextBox CssClass="details" ID="ContactName" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="ContactName" Text="*" ErrorMessage="Contact Name is Required" Display="Dynamic" runat="server"/>
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="email: " /><br />
                <asp:TextBox CssClass="details" ID="ContactEMail" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="ContactEMail" Text="*" ErrorMessage="Contact Email is Required" Display="Dynamic" runat="server"/>
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Job Title: " /><br />
                <asp:TextBox CssClass="details" ID="JobTitle" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="JobTitle" Text="*" ErrorMessage="Job Title is Required" Display="Dynamic" runat="server"/>
                <br />
                <asp:Label CssClass="detailHeading" runat="server" Text="Additional Details: " /><br />
                <asp:TextBox  CssClass="details" TextMode="MultiLine" Columns="50" Rows="5" ID="AddDetails" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="AddDetails" Text="*" ErrorMessage="Additional Info is Required" Display="Dynamic" runat="server"/>
                <br />
                <asp:Button runat="server" OnClick="SubmitPosting" Text="Submit Posting" />

                <asp:ValidationSummary id="valSum" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
            </div>
             
            
            
        </form>
    </div>
</body>
</html>