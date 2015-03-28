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

                <div>
                    <span class="postTitle">Add Student By Form</span><br />
                    <span class="detailHeading">Email</span><br />
                    <span class="details"><asp:TextBox runat="server" ID="txtEmail" /></span><br />
                    <asp:RegularExpressionValidator ValidationGroup="1" ValidationExpression="^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$" ControlToValidate="txtEMail" Text="*" ErrorMessage="Email is Not Valid" Display="Dynamic" runat="server" />
                    <span class="detailHeading">Student Id</span><br />
                    <span class="details"><asp:TextBox runat="server" ID ="txtStudentId" /></span><br />
                    <span class="detailHeading">First Name</span><br />
                    <span class="details"><asp:TextBox runat="server" ID ="txtFirstName" /></span><br />
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtFirstName" Text="*" ErrorMessage="First Name is Required" Display="Dynamic" runat="server"/>
                    <span class="detailHeading">Last Name</span><br />
                    <span class="details"><asp:TextBox runat="server" ID ="txtLastName" /></span><br />
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtLastName" Text="*" ErrorMessage="Last is Required" Display="Dynamic" runat="server"/>
                    <span class="detailHeading">Program Code</span><br />
                    <span class="details"><asp:TextBox runat="server" ID ="txtProgramCode" /></span><br />
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtProgramCode" Text="*" ErrorMessage="Program Code is Required" Display="Dynamic" runat="server"/>
                    <span class="detailHeading">Campus</span><br />
                    <span class="details"><asp:TextBox runat="server" ID ="txtCampus" /></span><br />
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtCampus" Text="*" ErrorMessage="Campus is Required" Display="Dynamic" runat="server"/>
                    <asp:ValidationSummary ValidationGroup="1" id="valSum" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                    <asp:Button ValidationGroup="1" OnClick="AddStudentByForm" runat="server" Text="Add Student"/>
                </div>
                <span class="postTitle">Add Instructor by Excel</span>
                <br />
                <asp:FileUpload  ID="fulInstructorUpload" runat="server" />
                <asp:Button Text="Add Instructors" onClick="AddInstructors" runat="server" />
            </div>
             
            
            
        </form>
    </div>
</body>
</html>