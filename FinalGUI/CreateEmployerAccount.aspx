<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateEmployerAccount.aspx.cs" Inherits="CreateEmployerAccount" %>

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
              name="frmCreateEmp"
              runat="server"              
              >
                                  
            <div id="Content" class="CreateAccount" runat="server">
                <div id="EmployerDetails" runat="server">
                    
                    <div id="companyInfo">
                        <h2>Company Info</h2>
                        <asp:Label Text="Company Name: " CssClass="detailHeading" runat="server" /><br />                        
                        <asp:TextBox ID="txtCompanyName" CssClass="details" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="txtCompanyName" Text="*" Display="Dynamic" ErrorMessage="eMail is Required" runat="server"/>
                        <br />
                        <asp:Label Text="Position: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtPosition" CssClass="details" runat="server" />
                        <br />
                        <asp:Label Text="Phone Number: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtPhoneNumber" TextMode="Phone" CssClass="details" runat="server" />
                        <br />
                        <br />
                        <asp:Label Text="Address: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtCompanyAddress" CssClass="details" runat="server" />*
                        <br />
                        <asp:Label Text="City: "  CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtCompanyCity" CssClass="details" runat="server" />*
                        <br />
                        <asp:Label Text="Province: " CssClass="detailHeading" runat="server" /><br />
                        <asp:ListBox ID="lbProvince" CssClass="details" runat="server" Rows="1">
                            <asp:ListItem Text="New Brunswick" Value="New Brunswick" />
                            <asp:ListItem Text="Nova Scotia" Value="New Brunswick" />
                            <asp:ListItem Text="Prince Edward Island" Value="New Brunswick" />
                            <asp:ListItem Text="Newfoundland" Value="New Brunswick" />
                            <asp:ListItem Text="Québec" Value="New Brunswick" />
                            <asp:ListItem Text="Ontario" Value="New Brunswick" />
                            <asp:ListItem Text="Alberta" Value="New Brunswick" />
                            <asp:ListItem Text="Saskatchewan" Value="New Brunswick" />
                            <asp:ListItem Text="Manitoba" Value="New Brunswick" />
                            <asp:ListItem Text="British Columbia" Value="New Brunswick" />
                            <asp:ListItem Text="Yukon" Value="New Brunswick" />
                            <asp:ListItem Text="Northwest Territories" Value="New Brunswick" />
                            <asp:ListItem Text="Nunavut" Value="New Brunswick" />
                        </asp:ListBox>*
                    </div>

                    <div id="personalInfo">
                        <h2>Personal Info</h2>
                        <asp:Label Text="eMail: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtEMail" CssClass="details" runat="server" />*
                        <br />
                        <asp:Label Text="First Name: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtFirstName" CssClass="details" runat="server" />*
                        <br />
                        <asp:Label Text="Last Name: " CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox ID="txtLastName" CssClass="details" runat="server" />*
                        <br />                    
                        <asp:Label Text="Password" CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox TextMode="Password" ID="txtPassword" CssClass="details" runat="server" />*
                        <br />
                        <asp:Label Text="Confirm Password" CssClass="detailHeading" runat="server" /><br />
                        <asp:TextBox TextMode="Password" ID="txtConfirmPsd" CssClass="details" runat="server" />*                               
                    </div>
                    
                </div>
                <div id="CreateButton">
                    <asp:Button Text="Create Account" Type="Submit" runat="server"/>
                </div>
                
                
            </div>       
                        
        </form>
    </div>
</body>
</html>