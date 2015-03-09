using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;
using FinalBL;

public partial class PracticumDetails : System.Web.UI.Page
{
    string email = "";
    int practicumID = 0;

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
            HttpContext.Current.Response.Redirect("LogIn.aspx"); 
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx"); 
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
            practicumID = Convert.ToInt32(StringEncryption.Decrypt(Request.QueryString["practicumID"]));

            Practicum practicum = new Practicum();                       

            practicum = PracticumDB.GetPracticumByID(practicumID);

            Student student = new Student();

            student = StudentDB.StudentByEMail(practicum.getStuEmail());

            if (practicum.getPostID() == 0)
            {
                PostDetails.InnerHtml = "<span class=\"postTitle\">Company: " + Server.HtmlEncode(practicum.getCompany()) + "</span><br />Student: " + student.getFullName() + "<br />Contact Email: " + practicum.getEmpEmail() + "<br />Details: " + Server.HtmlEncode(practicum.getAddDetails());

                Employer employer = new Employer();

                employer = EmployerDB.EmployerByEMail(practicum.getEmpEmail());

                if (employer == null)
                {
                    EmployerDetails.InnerHtml = "Employer Not Listed.<br />Email " + practicum.getEmpEmail() + ".";
                }
                else
                {
                    EmployerDetails.InnerHtml = "<span class=\"postTitle\">Employer Details</span><br />" + employer.getFirstName() + " " + employer.getLastName() + "<br />" + employer.getCompanyPosition() + " at " + employer.getCompanyName() + "<br />" + employer.getCompanyAddress() + " " + employer.getCompanyCity() + ", " + employer.getCompanyProvince() + "<br />Phone: " + employer.getPhoneNumber() + "<br />Email: " + employer.getEMail();
                }
                EmailDiv.InnerHtml = "<a href=\"mailto:" + practicum.getEmpEmail() + "?subject=Posting\">Email</a>";

            }
            else
            {
                Posting posting = PostingDB.GetPostingByPostID(practicum.getPostID());

                PostDetails.InnerHtml = "<span class=\"postTitle\">Company: " + Server.HtmlEncode(posting.getCompany()) + "</span><br />Student: " + student.getFullName() + "<br />Contact Email: " + posting.getEmpEmail() + "<br />Details: " + Server.HtmlEncode(posting.getAdditionalInfo());

                Employer employer = new Employer();

                employer = EmployerDB.EmployerByEMail(posting.getEmpEmail());

                if (employer == null)
                {
                    EmployerDetails.InnerHtml = "Employer Not Listed.<br />Email " + practicum.getEmpEmail() + ".";
                }
                else
                {
                    EmployerDetails.InnerHtml = "<span class=\"postTitle\">Employer Details</span><br />" + employer.getFirstName() + " " + employer.getLastName() + "<br />" + employer.getCompanyPosition() + " at " + employer.getCompanyName() + "<br />" + employer.getCompanyAddress() + " " + employer.getCompanyCity() + ", " + employer.getCompanyProvince() + "<br />Phone: " + employer.getPhoneNumber() + "<br />Email: " + employer.getEMail();
                }
                EmailDiv.InnerHtml = "<a href=\"mailto:" + practicum.getEmpEmail() + "?subject=Posting\">Email</a>";

            }

            
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }

    public void StartRemovePosting(object sender, EventArgs e)
    {
        RemoveDetails.Visible = true;
        btnOpenRemove.Visible = false;
    }

    public void ApprovePracticum(object sender, EventArgs e)
    {
        try
        {
            PracticumDB.ApprovePracticum(practicumID);

            string script = "<script type=\"text/javascript\">alert('Successfully Approved Practicum.');window.location = \"BrowsePracticums.aspx\"</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
        catch(Exception Ex)
        {
            string script = "<script type=\"text/javascript\">alert('An Error has Occured.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }

    public void RejectPracticum(object sender, EventArgs e)
    {
        Practicum practicum = new Practicum();
        practicum = PracticumDB.GetPracticumByID(practicumID);

        string reason = txtReason.Text;
        //
        //PostingDB.RemovePosting(posting, email, reason);
        //
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
        mail.To.Add(practicum.getStuEmail());

        if (practicum.getPostID() == 0)
        {
            mail.To.Add(practicum.getEmpEmail());
            mail.Subject = "C3 Posting Removal";
            mail.Body = "Your pending practicum with \"" + practicum.getCompany() + "\" has been denied."
                + "\n Reason: " + reason + ".";
        }
        else
        {
            Posting posting = PostingDB.GetPostingByPostID(practicum.getPostID());
            mail.To.Add(posting.getEmpEmail());
            mail.Subject = "C3 Posting Removal";
            mail.Body = "Your pending practicum with \"" + posting.getCompany() + "\" has been denied."
                + "\n Reason: " + reason + ".";
        }

        
        //
        
        //
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        smtp.Timeout = 300000;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //
        smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
        smtp.Send(mail);

        string script = "<script type=\"text/javascript\">alert('Successfully Removed Posting.');window.location = \"BrowsePracticums.aspx\"</script>";
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
