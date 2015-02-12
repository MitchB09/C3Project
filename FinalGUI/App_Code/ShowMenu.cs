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
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Home.aspx\">Home</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount1\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrpt(email) + "\">My Account</a>" +
                    "</div>" +
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Postings.aspx\">Postings</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"#\">Employers</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount2\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrpt(email) + "\">Upload Résumé</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"Information.aspx\">Information</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"LogOut.aspx\">Log Out</a>" +
                    "</div>";

            return menu;
        }

        public static string ShowEmployer(string email)
        {
            string menu = 
                "<div  class=\"menuItem\">" +
                    "<a href=\"Home.aspx\">Home</a>" +
               "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"#\">My Account</a>" +
               "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"CreatePosting.aspx\">Create Posting</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"Students.aspx\">Students</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"#\">View Applications</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"Information.aspx\">Information</a>" +
               "</div>" +            
               "<div class=\"menuItem\">" +
                    "<a href=\"LogOut.aspx\">Log Out</a>" +
               "</div>";

            return menu;
        }

        public static string ShowInstructor(string email)
        {
            string menu =
               "<div  class=\"menuItem\">" +
                    "<a href=\"Home.aspx\">Home</a>" +
               "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"#\">My Account</a>" +
                "</div>" +
               "<div class=\"menuItem\">" +
                    "<a href=\"Postings.aspx\">Postings</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"#\">Employers</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"CreatePosting.aspx\">Create Posting</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"Information.aspx\">Information</a>" +
                "</div>" +

                "<div class=\"menuItem\">" +
                    "<a href=\"LogOut.aspx\">Log Out</a>" +
                "</div>";

            return menu;
        }

        public static string ShowAdmin(string email)
        {
            string menu =
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Home.aspx\">Home</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount1\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrpt(email) + "\">My Account</a>" +
                    "</div>" +
                    "<div  class=\"menuItem\">" +
                        "<a href=\"Postings.aspx\">Postings</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"#\">Employers</a>" +
                    "</div>" +
                    "<div class=\"menuItem\" id=\"StuAccount2\" runat=\"server\">" +
                        "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrpt(email) + "\">Upload Résumé</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"Information.aspx\">Information</a>" +
                    "</div>" +
                    "<div class=\"menuItem\">" +
                        "<a href=\"LogOut.aspx\">Log Out</a>" +
                    "</div>";

            return menu;
        }
    }
}
