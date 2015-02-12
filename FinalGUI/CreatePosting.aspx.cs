using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalBL;

using FinalGUI.ShowMenu;

public partial class CreatePosting : System.Web.UI.Page
{
    string email;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        email = "";

        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }
        else
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        
        //Redirects if no usertype is present (i.e. no one is signed in)
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
            if (EmployerDB.ApprovedEmployer(email))
            {
                ShowEmployer(email); 
            }
            else
            {
                UnvettedEmployer(email);
            }
                        
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);            
        }         


    }
    public void ShowStudent(string email)
    {

        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
        //StudentContent.Visible = true;

        //StuAccount1.InnerHtml = "<a href=\"MyAccount.aspx?email=" + email + "\">My Account</a>";
        //StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?email=" + email + "\">Upload Résumé</a>";

        InstructorMenu.Visible = false;
        EmployerMenu.Visible = false;
        Content.Visible = false;        
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        Content.Visible = true;

        Employer employer = EmployerDB.EmployerByEMail(email);
        
        CompanyName.Text = employer.getCompanyName();
        CompanyName.ReadOnly = true;
        CompanyName.BorderWidth = 0;
        CompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDD");

        ContactName.Text = employer.getFirstName() + " " + employer.getLastName();
        ContactName.ReadOnly = true;
        ContactName.BorderWidth = 0;
        ContactName.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDD");

        ContactEMail.Text = employer.getEMail();
        ContactEMail.ReadOnly = true;
        ContactEMail.BorderWidth = 0;
        ContactEMail.BackColor = System.Drawing.ColorTranslator.FromHtml("#DDD");

        InstructorMenu.Visible = false;
        
    }

    public void UnvettedEmployer(string email)
    {
        StudentMenu.Visible = false;
        InstructorMenu.Visible = false;
        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);

        Content.InnerHtml = "<p>You must be an approved employer to create a job posting</p>";
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;  
        EmployerMenu.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        Content.Visible = true;


    }

    protected void SubmitPosting(object sender, EventArgs e)
    {
        if (PostingDB.CreatePosting(ContactEMail.Text, JobTitle.Text, AddDetails.Text) > 0)
        {
            string script = "<script type=\"text/javascript\">alert('Posting Successfully Created.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            JobTitle.Text = "";
            AddDetails.Text = "";
        }
        else
        {
            string script = "<script type=\"text/javascript\">alert('An Error Has Occured.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }
}