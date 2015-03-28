<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadPracticum.aspx.cs" Inherits="UploadPracticum" %>

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
                
                <asp:RadioButton Text="From Post ID" ID="rbPostID" GroupName="FromSource" Checked="true" OnCheckedChanged="SourceChange" runat="server" AutoPostBack="true" />
                <asp:RadioButton Text="From Employer" ID="rbEmp" GroupName="FromSource" Checked="false" OnCheckedChanged="SourceChange" runat="server" AutoPostBack="true" />
                
                <br />
                <br />

                <div id="fromPostId" runat="server">
                    <asp:Label CssClass="detailHeading" runat="server" Text="Post ID: " /><br />
                    <asp:TextBox CssClass="details" ID="txtPostID" runat="server" />
                    <asp:RequiredFieldValidator ControlToValidate="txtPostID" ValidationGroup="1" Text="*" ErrorMessage="Post Id is Required" Display="Dynamic" runat="server"/>
                    <br />
                    <asp:ValidationSummary id="valSumPostID" ValidationGroup="1" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                    <br />
                    <asp:Button runat="server" OnClick="SubmitPracticum" ValidationGroup="1"  Text="Submit Practicum" />
                </div>                
                
                <div id="fromEmployer" runat="server">                
                    <asp:Label CssClass="detailHeading" runat="server" Text="Company: " />
                    <br />
                    <asp:TextBox CssClass="details" ID="txtCompanyName" runat="server" Enabled="false"/>
                    <asp:RequiredFieldValidator ControlToValidate="txtCompanyName" ValidationGroup="2" Text="*" ErrorMessage="Company Name is Required" Display="Dynamic" runat="server"/>
                    
                    <br />

                    <asp:Label CssClass="detailHeading" runat="server" Text="Contact: " />
                    <br />
                    <asp:TextBox CssClass="details" ID="txtContactName" runat="server" Enabled="false"/>
                    <asp:RequiredFieldValidator ControlToValidate="txtContactName" ValidationGroup="2" Text="*" ErrorMessage="Contact Name is Required" Display="Dynamic" runat="server"/>
                    
                    <br />

                    <asp:Label CssClass="detailHeading" runat="server" Text="Email: " />
                    <br />
                    <asp:TextBox CssClass="details" ID="txtContactEMail" runat="server" Enabled="false"/>
                    <asp:RequiredFieldValidator ControlToValidate="txtContactEMail" ValidationGroup="2" Text="*" ErrorMessage="Contact Email is Required" Display="Dynamic" runat="server"/>
                    <asp:RegularExpressionValidator ValidationExpression="^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$" ControlToValidate="txtContactEMail" Text="*"  ValidationGroup="2" ErrorMessage="Email is Not Valid" Display="Dynamic" runat="server"/>
                    
                    <br /> 
                                   
                    <asp:Label CssClass="detailHeading" runat="server" Text="Additional Details: " />
                    <br />
                    <asp:TextBox  CssClass="details" TextMode="MultiLine" Columns="50" Rows="5" ID="txtAddDetails" runat="server" Enabled="false"/>
                    <asp:ValidationSummary id="valSum" ValidationGroup="2" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                    
                    <br />

                    <asp:Button runat="server" OnClick="SubmitPracticum" ValidationGroup="2" Text="Submit Practicum" />

                </div>
            </div>
             
            
            
        </form>
    </div>
</body>
</html>