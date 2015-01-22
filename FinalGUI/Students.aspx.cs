using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FinalBL;

public partial class Students : System.Web.UI.Page
{
    string eMail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
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
            ShowEmployer();
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor();
        }

        List<Student> studentList = new List<Student>();

        try
        {
            studentList = StudentDB.getStudentDisplayList();

            string content = "";

            foreach(Student student in studentList)
            {
                content += "<div class=\"student\"><a href=\"StudentDetails.aspx?eMail=" + student.getEMail() + "\">" + student.getFirstName() + " " + student.getLastName() + "</a><br />" +  student.getProgram() + "<br />" + student.getCampus() + "</div><hr />";
            }
            StudentContent.InnerHtml = content;
        }
        catch(Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }

    }

    public void ShowStudent()
    {
        StudentMenu.Visible = true;
        //StudentContent.Visible = true;

        StuAccount1.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Upload Résumé</a>";

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        // InstructorContent.Visible = false;
    }

    public void ShowEmployer()
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = true;
        //EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = false;
    }

    public void ShowInstructor()
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = true;
        //InstructorContent.Visible = true;
    }
}