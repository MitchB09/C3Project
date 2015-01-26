using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalBL;

public partial class CreatePosting : System.Web.UI.Page
{
    string eMail;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        eMail = "";

        if (Session["eMail"] != null)
        {
            eMail = Session["eMail"].ToString();
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
            ShowStudent();
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            if (EmployerDB.ApprovedEmployer(eMail))
            {
                ShowEmployer(eMail); 
            }
            else
            {
                UnvettedEmployer();
            }
                        
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor();            
        }         


    }
    public void ShowStudent()
    {
        
        StudentMenu.Visible = true;
        //StudentContent.Visible = true;

        StuAccount1.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Upload Résumé</a>";

        InstructorMenu.Visible = false;
        EmployerMenu.Visible = false;
        Content.Visible = false;        
    }

    public void ShowEmployer(string eMail)
    {
        StudentMenu.Visible = false;        

        EmployerMenu.Visible = true;
        Content.Visible = true;

        Employer employer = EmployerDB.EmployerByEMail(eMail);
        
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

    public void UnvettedEmployer()
    {
        StudentMenu.Visible = false;
        InstructorMenu.Visible = false;
        Content.InnerHtml = "<p>You must be an approved employer to create a job posting</p>";
    }

    public void ShowInstructor()
    {
        StudentMenu.Visible = false;  
        EmployerMenu.Visible = false;
        
        InstructorMenu.Visible = true;
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