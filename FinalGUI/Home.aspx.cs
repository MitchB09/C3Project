using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeStudent : System.Web.UI.Page
{
    string eMail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
                
        //Checks if the is an email stored in the session if not returns to LogIn.aspx
        if (Session["eMail"] != null)
        {
            eMail = Session["eMail"].ToString();
        }
        else{
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }

        //Checks which type user is if none return to LigIn.aspx
        if (Session["usertype"] == null)
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Student")
        {
            ShowStudent();            
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            ShowEmployer();
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor();            
        }
                
    }
    
    public void ShowStudent()
    {
        StudentMenu.Visible = true;
        StudentContent.Visible = true;

        StuAccount.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Go to My Account</a><br />" +
                "<small>View and make schanges to your account.</small>";
        StuAccount3.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Upload Résumé</a>";
        StuAccount4.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Upload new Résumé;</a><br />" +
                "<small>Change your current résumé</small>";

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;
        
        InstructorMenu.Visible = false;     
        InstructorContent.Visible = false;
    }

    public void ShowEmployer()
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;

        EmployerMenu.Visible = true;
        EmployerContent.Visible = true;

        //EmpAccount.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        EmpAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Go to My Account</a><br />" +
                "<small>View and make schanges to your account.</small>";

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;
    }

    public void ShowInstructor()
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.Visible = true;
        InstructorContent.Visible = true;

        InsAccount.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        InsAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Go to My Account</a><br />" +
                "<small>View and make schanges to your account.</small>";
    }
}