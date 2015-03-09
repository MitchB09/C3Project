using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class HomeStudent : System.Web.UI.Page
{
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
                
        //Checks if the is an email stored in the session if not returns to LogIn.aspx
        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
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
            ShowStudent(email);            
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            ShowEmployer(email);
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);            
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);
        }
                
    }
    
    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
        StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrypt(email) + "\">Go to My Account</a><br /><small>View and make schanges to your account.</small>";
        StuAccount4.InnerHtml = "<a href=\"MyAccount.aspx?email=" + StringEncryption.Encrypt(email) + "\">Upload new Résumé</a><br /><small>Change your current résumé</small>";
        StudentContent.Visible = true;
        
        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;
        
        InstructorMenu.Visible = false;     
        InstructorContent.Visible = false;

        AdminMenu.Visible = false;
        AdminContent.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        EmployerContent.Visible = true;        

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;

        AdminMenu.Visible = false;
        AdminContent.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        InstructorContent.Visible = true;

        AdminMenu.Visible = false;
        AdminContent.Visible = false;
    }

    public void ShowAdmin(string email)
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;

        AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);
        AdminContent.Visible = true;
    }
}