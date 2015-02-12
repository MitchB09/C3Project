using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;
using FinalBL;


public partial class PostingDetails : System.Web.UI.Page
{
    string email = "";
    int postID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            ShowEmployer(email);
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);
        }

        try
        {
            postID = Convert.ToInt32(StringEncryption.Decrypt(Request.QueryString["postID"]));

            Posting posting = new Posting();

            posting = PostingDB.GetPostingByPostID(postID);

            PostDetails.InnerHtml = "<span class=\"postTitle\">" + Server.HtmlEncode(posting.getJobTitle()) + "</span><br />" + posting.getPostID() + "<br />" + Server.HtmlEncode(posting.getAdditionalInfo());

            Employer employer = new Employer();

            employer = EmployerDB.EmployerByEMail(posting.getEmpEmail());

            if (employer == null)
            {
                EmployerDetails.InnerHtml = "Employer Not Listed. Posting Created By Instuctor.<br />Email " + posting.getEmpEmail() + " or relevant instuctor for further details.";
            }
            else
            {
                EmployerDetails.InnerHtml = employer.getFirstName() + " " + employer.getLastName() + "<br />" + employer.getCompanyPosition() + " at " + employer.getCompanyName() + "<br />" + employer.getCompanyAddress() + " " + employer.getCompanyCity() + ", " + employer.getCompanyProvince() + "<br />Phone: " + employer.getPhoneNumber() + "<br />Email: " + employer.getEMail();
            }
            EmailDiv.InnerHtml = "<a href=\"mailto:" + posting.getEmpEmail() + "?subject=Posting\">Email</a>";

        }
        catch
        {

        }
    }

    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        // InstructorContent.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        //EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        //InstructorContent.Visible = true;
    }

}
