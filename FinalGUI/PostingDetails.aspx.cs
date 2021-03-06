﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;

using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;
using FinalBL;


public partial class PostingDetails : System.Web.UI.Page
{
    string email = "";
    int postID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminControls.Visible = false;

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
            AdminControls.Visible = true;
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);
            AdminControls.Visible = true;
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
                EmployerDetails.InnerHtml = employer.getFirstName() + " " + employer.getLastName() + "<br />" + employer.getCompanyPosition() + " at " + employer.getCompanyName() + "<br />" + employer.getCompanyAddress() + " " + employer.getCompanyCity() + ", " + employer.getCompanyProvince() + "<br />Phone: " + employer.getPhoneNumber();
            }
            EmailDiv.InnerHtml = "<a href=\"mailto:" + posting.getEmpEmail() + "?subject=Posting\">Email: " + posting.getEmpEmail() + "</a>";            

        }
        catch
        {

        }
    }

    public void StartRemovePosting(object sender, EventArgs e)
    {
        RemoveDetails.Visible = true;
        btnOpenRemove.Visible = false;
    }

    public void RemovePosting(object sender, EventArgs e)
    {
        Posting posting = new Posting();
        posting = PostingDB.GetPostingByPostID(postID);

        string reason = txtReason.Text;

        PostingDB.RemovePosting(posting, email, reason);

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
        mail.To.Add(posting.getEmpEmail());
        //
        mail.Subject = "C3 Posting Removal";
        mail.Body = "Your posting titled \"" + posting.getJobTitle() + "\" has been removed."
            + "\n Reason: " + reason + ".";
        //
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        smtp.Timeout = 300000;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //
        smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
        smtp.Send(mail);

        string script = "<script type=\"text/javascript\">alert('Successfully Removed Posting.');window.location = \"Postings.aspx\"</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
    }

    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        // InstructorContent.Visible = false;

        AdminMenu.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        //EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = false;

        AdminMenu.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        //InstructorContent.Visible = true;

        AdminMenu.Visible = false;
    }

    public void ShowAdmin(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = true;

        AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);
    }

    
}
