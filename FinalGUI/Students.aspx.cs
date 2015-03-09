using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using FinalBL;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class Students : System.Web.UI.Page
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
            ShowStudent(email);
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            if (EmployerDB.ApprovedEmployer(email))
            {
                ShowEmployer(email);
                ShowContent(page);
            }
            else
            {
                UnvettedContent();
                ShowEmployer(email);
            }
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);
            ShowContent(page);
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
    public void ShowContent(int pageNum)
    {
        List<Student> studentList = new List<Student>();

        try
        {
            studentList = StudentDB.getStudentRange(pageNum);

            string content = "";

            foreach (Student student in studentList)
            {
                content += "<div class=\"student\"><a href=\"StudentDetails.aspx?email=" + StringEncryption.Encrypt(student.getEMail()) + "\">" + student.getFirstName() + " " + student.getLastName() + "</a><br />" + student.getProgram() + "<br />" + student.getCampus() + "</div><hr />";
            }

            //Start div for pageListing
            content += "<div id=\"pageListing\">";

            //If the page number is greater then 1 add a left arrow.
            if (pageNum > 1)
            {
                content += "<a href=\"Students.aspx?page=" + (pageNum - 1) + "\"><img src=\"images/LeftArrow.png\" height=\"12px\" width=\"12px\"/></a>";
            }

            //add current page number of total page number
            content += "&nbsp;Page " + pageNum + " of " + (int)Math.Ceiling((double)StudentDB.StudentCount() / 5) + "&nbsp;";

            //If current page is less than total count page add a right arrow.
            if (pageNum < (int)Math.Ceiling((double)StudentDB.StudentCount() / 5))
            {
                content += "<a href=\"Students.aspx?page=" + (pageNum + 1) + "\"><img src=\"images/RightArrow.png\" height=\"12px\" width=\"12px\"/></a>";
            }

            //end div for pageListing
            content += "</div>";

            StudentContent.InnerHtml = content;
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }

    public void UnvettedContent()
    {
        List<Student> studentList = new List<Student>();

        try
        {
            studentList = StudentDB.getStudentDisplayList();

            string content = "";

            foreach (Student student in studentList)
            {
                content += "<div class=\"student\">" + student.getFirstName() + " " + student.getLastName().Substring(0,1) + "<br />" + student.getProgram() + "<br />" + student.getCampus() + "</div><hr />";
            }
            StudentContent.InnerHtml = content;
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
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