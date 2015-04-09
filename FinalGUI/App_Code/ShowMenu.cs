using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalGUI.StringEncrypt;

/// <summary>
/// Summary description for ShowMenu
/// </summary>
/// 

namespace FinalGUI.ShowMenu
{
    public class ShowMenu
    {
        public ShowMenu()
        {

        }

        public static string ShowStudent(string email)
        {
            string menu =
                
                    "<div  class=\"menuItemTop\">" +
                        "<a href=\"Home.aspx\">Home</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount1\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + HttpUtility.UrlEncode(StringEncryption.Encrypt(email)) + "\">My Account</a>" +
                    "</div>" +
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Postings.aspx\">Postings</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"UploadPracticum.aspx\">Upload Practicum</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount2\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + HttpUtility.UrlEncode(StringEncryption.Encrypt(email)) + "\">Upload Résumé</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"Information.aspx\">Information</a>" +
                    "</div>" +
                    "<div class=\"menuItemBottom\">" +
                        "<a href=\"LogOut.aspx\">Log Out</a>" +
                    "</div>";

            return menu;
        }

        public static string ShowEmployer(string email)
        {
            string menu =
                "<div  class=\"menuItemTop\">" +
                    "<a href=\"Home.aspx\">Home</a>" +
               "</div>" +               
               "<div class=\"menuItem\">" +
                    "<a href=\"CreatePosting.aspx\">Create Posting</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"Students.aspx\">Browse Students</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"MyPostings.aspx\">My Postings</a>" +
               "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"UpdatePassword.aspx\">Update Password</a>" +
               "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"Information.aspx\">Information</a>" +
               "</div>" +
               "<div class=\"menuItemBottom\">" +
                    "<a href=\"LogOut.aspx\">Log Out</a>" +
                "</div>";

            return menu;
        }

        public static string ShowInstructor(string email)
        {
            string menu =
               "<div  class=\"menuItemTop\">" +
                    "<a href=\"Home.aspx\">Home</a>" +
               "</div>" +               
               "<div class=\"menuItem\">" +
                    "<a href=\"Postings.aspx\">Postings</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"Students.aspx\">Students</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"CreatePosting.aspx\">Create Posting</a>" +
                "</div>" +
                "<div class=\"menuItem\">" +
                    "<a href=\"BrowsePracticums.aspx\">Practicums</a>" +
                "</div>" +
                "<div class=\"menuItem\">" +
                    "<a href=\"Information.aspx\">Information</a>" +
                "</div>" +

                "<div class=\"menuItemBottom\">" +
                    "<a href=\"LogOut.aspx\">Log Out</a>" +
                "</div>";

            return menu;
        }

        public static string ShowAdmin(string email)
        {
            string menu =
                    "<div  class=\"menuItemTop\">" +
                        "<a href=\"Home.aspx\">Home</a>" +
                    "</div>" +
                    
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Postings.aspx\">Postings</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"BrowsePracticums.aspx\">Practicums</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"AddAccounts.aspx\">Add Accounts</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"Information.aspx\">Information</a>" +
                    "</div>" +
                    "<div class=\"menuItemBottom\">" +
                        "<a href=\"LogOut.aspx\">Log Out</a>" +
                    "</div>";

            return menu;
        }

        public static string ShowUnknown()
        {
            string menu =
                    "<div  class=\"menuItemTop\">" +
                        "<a href=\"LogIn.aspx\">Log In</a>" +
                    "</div>" +
                    "<div class=\"menuItemBottom\">" +
                        "<a href=\"CreateEmployerAccount.aspx\">Create Account</a>" +
                    "</div>";

            return menu;
        }
    }
}
