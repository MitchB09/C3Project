using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;
using FinalBL;

public partial class MyPostingDetails : System.Web.UI.Page
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

        EditContent.Visible = false;

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
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);
        }

        try
        {
            postID = Convert.ToInt32(StringEncryption.Decrypt(Request.QueryString["postID"]));

            Posting posting = new Posting();

            posting = PostingDB.GetPostingByPostID(postID);

            PostDetails.InnerHtml = "<span class=\"postTitle\">" + posting.getJobTitle() + "</span><br />" + posting.getPostID() + "<br />" + posting.getAdditionalInfo();

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


        }
        catch(Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('Error Finding Posting. Error: " + ex + "');window.location = \"MyPostings.aspx\"</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }

    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
        //StudentContent.Visible = true;

        //StuAccount1.InnerHtml = "<a href=\"MyAccount.aspx?email=" + email + "\">My Account</a>";
        //StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?email=" + email + "\">Upload Résumé</a>";

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        // InstructorContent.Visible = false;

        AdminMenu.Visible = false;
        //EmployerContent.Visible = false;
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
        //EmployerContent.Visible = false;
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
        //EmployerContent.Visible = false;
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

    protected void EditPosting(object sender, EventArgs e)
    {
        Content.Visible = false;
        EditContent.Visible = true;

        try
        {
            postID = Convert.ToInt32(StringEncryption.Decrypt(Request.QueryString["postID"]));

            Posting posting = new Posting();

            posting = PostingDB.GetPostingByPostID(postID);

            txtJobTitle.Text = posting.getJobTitle();
            txtAdditionalDetails.Text = posting.getAdditionalInfo();
        }
        catch
        {
            string script = "<script type=\"text/javascript\">alert('Error Finding Posting.');window.location = \"MyPostings.aspx\"</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }

    }

    public void RemovePosting(object sender, EventArgs e)
    {
        Posting posting = new Posting();
        posting = PostingDB.GetPostingByPostID(postID);        

        PostingDB.RemovePosting(posting, email, "Employer Removed Posting");

        string script = "<script type=\"text/javascript\">alert('Successfully Removed Posting.');window.location = \"MyPostings.aspx\"</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
    }

    protected void UpdatePosting(object sender, EventArgs e)
    {
        try
        {
            if (PostingDB.UpdatePosting(postID, txtJobTitle.Text, txtAdditionalDetails.Text) > 0)
            {
                string script = "<script type=\"text/javascript\">alert('Posting Successfully Updated.');window.location = \"MyPostingDetails.aspx?PostID=" + StringEncryption.Encrypt(postID.ToString()) + "\"</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('An Error Has Occured.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
        }
        catch(Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
        

    }
}