<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
            <div class="content" runat="server">
                <div id="StudentContent"  runat="server">
                
                </div> 
                <div id="UpdateContent" runat="server">
                    <h1 runat="server" id="txtName"></h1><br />
                    <!--Email-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="email: " /><br />
                    <asp:Label CssClass="details" Text="" runat="server" ID="txtEmail" /><br />
                    <!--Program-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="Program: " /><br />
                    <asp:Label runat="server" CssClass="details" Text="" ID="txtProgram" /><br />
                    <!--Phone-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="Phone: " /><br />
                    <asp:TextBox CssClass="details" runat="server" ID="txtPhone" Text="" /><br />
                    <!--Address-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="Address: " /><asp:Label runat="server" CssClass="altDetailHeading" Text="City: " /><br />
                    <asp:TextBox CssClass="details" runat="server" ID="txtAddress" Text="" /><asp:TextBox CssClass="details" runat="server" ID="txtCity" Text="" /><br />
                    
                    
                    <!--Campus-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="Campus" /><br />
                    <asp:Label runat="server" CssClass="details" Text="" ID="txtCampus" /><br />
                    <!--Additional Info-->
                    <asp:Label runat="server" CssClass="detailHeading" Text="Additional Info: " /><br />
                    <asp:TextBox CssClass="details" runat="server" ID="txtAdditionalInfo" Text="" TextMode="MultiLine" Columns="50" Rows="5" MaxLength="255" />
                    <br />
                    <br />
                    <asp:Button runat="server" OnClick="UpdateStudent" Text="Save"/>
                    
                </div>
                <div id="Resume" runat="server">
                    <span class="detailHeading">Résumé: </span>
                    <br />
                    <span class="details">
                        <asp:FileUpload ID="ResumeUpload" runat="server" />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
                        <br />
                        <br />
                        <asp:Button runat="server" OnClick="Unnamed_Click" Text="Update Info" />
                        <a href="UpdatePassword.aspx" onclick="">Update Password</a>
                    </span>
                </div>



                <div id="EmployerContent" class="content1" runat="server">
                    <div class="homeMenuOption">
                        <a href="#">Go to My Account</a>
                        <br />
                        <small>View and make schanges to your account.</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">View Student Profiles</a>
                        <br />
                        <small>Check out all current available posings</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">View List of Potential Employers</a>
                        <br />
                        <small>Check the list of potential employers in the province</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">Upload new Posting</a>
                        <br />
                        <small>Change your current résumé</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">View Practicum Information</a>
                        <br />
                        <small>View general information about the practicums</small>
                    </div>
                </div>
                <div id="InstructorContent"  class="content1" runat="server">
                    <div class="homeMenuOption">
                        <a href="#">Go to My Account</a>
                        <br />
                        <small>View and make schanges to your account.</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">Go to Current Postings</a>
                        <br />
                        <small>Check out all current available posings</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">Edit List of Potential Employers</a>
                        <br />
                        <small>Check the list of potential employers in the province</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="UnvettedEmployers.aspx">View Unvetted Employers</a>
                        <br />
                        <small>Change your current résumé</small>
                    </div>
                    <hr />
                    <div class="homeMenuOption">
                        <a href="#">View Pending Practicums</a>
                        <br />
                        <small>View general information about the practicums</small>
                    </div>
                </div> 
            </div>
            
        </form>
    </div>
    
</body>
</html>
