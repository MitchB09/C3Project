using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;

using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;
using FinalBL;

public partial class BrowsePracticums : System.Web.UI.Page
{
    string email = "";
    int page = 1;

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

        if (Request.QueryString["page"] != null)
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
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
            ShowEmployer(email);
            ShowContent(page);
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);
            ShowContent(page);
        }


    }

    public void ShowContent(int pageNum)
    {
        List<Practicum> practicumList = new List<Practicum>();

        try
        {
            practicumList = PracticumDB.GetUnapprovedPracticums(pageNum);
            int practicumCount = PracticumDB.GetUnapprovedPracticumCount();

            string content = "";

            if (practicumCount != 0)
            {
                //For each posting in list for this page(i.e. page 1 is postings 1 to 5)
                foreach (Practicum practicum in practicumList)
                {
                    if (practicum.getPostID() == 0)
                    {
                        content += "<div class=\"posting\"><a href=\"PracticumDetails.aspx?practicumID=" + StringEncryption.Encrypt(practicum.getPracticumID().ToString()) + "\">" + practicum.getCompany() + "</a><br />" + practicum.getStuEmail() + "<br />Date Added: " +
                        practicum.getDateAdded().ToShortDateString() + "</div><hr />";
                    }
                    else
                    {
                        Posting posting = PostingDB.GetPostingByPostID(practicum.getPostID());
                        content += "<div class=\"posting\"><a href=\"PracticumDetails.aspx?practicumID=" + StringEncryption.Encrypt(practicum.getPracticumID().ToString()) + "\">" + posting.getCompany() + "</a><br />" + practicum.getStuEmail() + "<br />Date Added: " +
                        practicum.getDateAdded().ToShortDateString() + "</div><hr />";
                    }
                }
            
                   

                //Start div for pageListing
                content += "<div id=\"pageListing\">";

                //If the page number is greater then 1 add a left arrow.
                if (pageNum > 1)
                {
                    content += "<a href=\"BrowsePracticums.aspx?page=" + (pageNum - 1) + "\"><img src=\"images/LeftArrow.png\" height=\"12px\" width=\"12px\"/></a>";
                }

                //add current page number of total page number
                content += "&nbsp;Page " + pageNum + " of " + (int)Math.Ceiling((double)practicumCount / 5) + "&nbsp;";

                //If current page is less than total count page add a right arrow.
                if (pageNum < (int)Math.Ceiling((double)practicumCount / 5))
                {
                    content += "<a href=\"BrowsePracticums.aspx?page=" + (pageNum + 1) + "\"><img src=\"images/RightArrow.png\" height=\"12px\" width=\"12px\"/></a>";
                }

                //end div for pageListing
                content += "</div>";
            }
            else
            {
                content += "No Pending Unapproved Practicums";
            } 

            Content.InnerHtml = content;
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
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