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

                
                    <span class="postTitle">Add Student By Form</span>
                    <br />
                <div class="AddForm">
                    <span class="detailHeading">
                        Email
                    </span>                    
                    <br />                    
                    <span class="details">
                        <asp:TextBox runat="server" ID="txtEmail" />
                    </span>
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtStudentId" Text="*" ErrorMessage="Student Email is Required" Display="Dynamic" runat="server"/>
                    <asp:RegularExpressionValidator ValidationGroup="1" ValidationExpression="^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$" ControlToValidate="txtEMail" Text="*" ErrorMessage="Email is Not Valid" Display="Dynamic" runat="server" />
                    <br />                    
                    
                    <span class="detailHeading">
                        Student Id
                    </span> 
                    <br />                   
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtStudentId" />
                    </span>
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtStudentId" Text="*" ErrorMessage="Student Id is Required" Display="Dynamic" runat="server"/>
                    <br />
                    
                    
                    <span class="detailHeading">
                        First Name
                    </span>                    
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtFirstName" />
                    </span>
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtFirstName" Text="*" ErrorMessage="First Name is Required" Display="Dynamic" runat="server"/>
                    <br />             
                    
                    
                    <span class="detailHeading">
                        Last Name
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtLastName" />
                    </span>                    
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtLastName" Text="*" ErrorMessage="Last Name is Required" Display="Dynamic" runat="server"/>
                    <br />

                    
                    <span class="detailHeading">
                        Program Code
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtProgramCode" />
                    </span>                   
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtProgramCode" Text="*" ErrorMessage="Program Code is Required" Display="Dynamic" runat="server"/>
                     <br />


                    <span class="detailHeading">
                        Campus
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtCampus" />
                    </span>                    
                    <asp:RequiredFieldValidator ValidationGroup="1" ControlToValidate="txtCampus" Text="*" ErrorMessage="Campus is Required" Display="Dynamic" runat="server"/>
                    <br />
                    <br />

                    <asp:ValidationSummary ValidationGroup="1" id="valSum" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                    <asp:Button ValidationGroup="1" OnClick="AddStudentByForm" runat="server" Text="Add Student"/>
                </div>

                <br />

                <span class="postTitle">Add Instructor by Excel</span>
                <br />
                <asp:FileUpload  ID="fulInstructorUpload" runat="server" />
                <asp:Button Text="Add Instructors" onClick="AddInstructors" runat="server" />
                <br />
                <br />
                  <span class="postTitle">Add Instructor By Form</span>
                    <br />
                <div class="AddForm">
                    <span class="detailHeading">
                        Email
                    </span>                    
                    <br />                    
                    <span class="details">
                        <asp:TextBox runat="server" ID="txtInstEmail" />
                    </span>
                    <asp:RequiredFieldValidator ValidationGroup="2" ControlToValidate="txtInstEmail" Text="*" ErrorMessage="Student Email is Required" Display="Dynamic" runat="server"/>
                    <asp:RegularExpressionValidator ValidationGroup="2" ValidationExpression="^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$" ControlToValidate="txtInstEmail" Text="*" ErrorMessage="Email is Not Valid" Display="Dynamic" runat="server" />
                    <br />                  
                    
                    <span class="detailHeading">
                        First Name
                    </span>                    
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtInsFirstName" />
                    </span>
                    <asp:RequiredFieldValidator ValidationGroup="2" ControlToValidate="txtInsFirstName" Text="*" ErrorMessage="First Name is Required" Display="Dynamic" runat="server"/>
                    <br />             
                    
                    
                    <span class="detailHeading">
                        Last Name
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtInsLastName" />
                    </span>                    
                    <asp:RequiredFieldValidator ValidationGroup="2" ControlToValidate="txtInsLastName" Text="*" ErrorMessage="Last Name is Required" Display="Dynamic" runat="server"/>
                    <br />

                    
                    <span class="detailHeading">
                        Program Code
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtInsProgCode" />
                    </span>                   
                    <asp:RequiredFieldValidator ValidationGroup="2" ControlToValidate="txtInsProgCode" Text="*" ErrorMessage="Program Code is Required" Display="Dynamic" runat="server"/>
                     <br />


                    <span class="detailHeading">
                        Campus
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtInsCampus" />
                    </span>                    
                    <asp:RequiredFieldValidator ValidationGroup="2" ControlToValidate="txtInsCampus" Text="*" ErrorMessage="Campus is Required" Display="Dynamic" runat="server"/>
                    <br />

                    <span class="detailHeading">
                        Contact Information
                    </span>
                    <br />
                    <span class="details">
                        <asp:TextBox runat="server" ID ="txtContactInfo" />
                    </span>                    
                    <br />

                    <br />

                    <asp:ValidationSummary ValidationGroup="2" id="ValidationSummary1" HeaderText="The Following Fields are Required" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true"  runat="server"/>
                    <asp:Button ValidationGroup="2" OnClick="AddInstructorByForm" runat="server" Text="Add Instructor"/>
                </div>
            </div>
             
            
            
        </form>
    </div>
</body>
</html>