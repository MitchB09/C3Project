using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FinalBL;

public partial class StudentDetails : System.Web.UI.Page
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

        eMail = Request.QueryString["eMail"];

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
            ShowResume(eMail);
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor();
            ShowResume(eMail);
        }

        


        
        try
        {
            Student student = StudentDB.StudentByEMail(eMail);


            string studentName = student.getFirstName() + " " + student.getLastName();
            string studentID = student.getStudentID();
            string studentProgram = student.getProgram();
            string studentInfo = student.getAdditionalInfo();

            Resume foundResume = ResumeDB.GetResumeName(eMail);

            string content = studentName + "<br />" + studentID + "<br />" + studentProgram + "<br />" + studentInfo + " <br / >";
            StudentStuff.InnerHtml = content;                        

            ResumeTitle.InnerHtml = " " + foundResume.getFileName();
            
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }

    public void Download(object sender, EventArgs e)
    {
        try
        {
            eMail = Request.QueryString["eMail"];

            Resume foundResume = ResumeDB.GetResume(eMail);

            FileStream fStream = new FileStream("C:\\tester\\" + foundResume.getFileName(), FileMode.Create);
            fStream.Write(foundResume.getDocData(), 0, foundResume.getDocData().Length);
            fStream.Close();
            fStream.Dispose();
        }
        catch(Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
        
    }

    public void ShowStudent()
    {
        ResumeDiv.Visible = false;

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

    public void ShowResume(string email)
    {
        if (ResumeDB.FindResume(email))
        {
            ResumeDiv.Visible = true;
        }
        else
        {
            ResumeDiv.InnerHtml = "No Resumé Available";
        }
    }
}