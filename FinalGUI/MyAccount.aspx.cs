using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalBL;

public partial class MyAccount : System.Web.UI.Page
{
    string eMail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        

        //Checks if the is an email stored in the session
        if (Session["eMail"] != null)
        {
            eMail = Session["eMail"].ToString();
        }
        else
        {
            eMail = String.Empty;
        }

        if (Session["usertype"] == null || Request.QueryString["eMail"] != eMail)
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

    }

    public void ShowStudent()
    {
        Student student = new Student();
        student = StudentDB.StudentByEMail(eMail);

        string content = "<h1>" + student.getFullName() + "</h1><br />" +
            "<span class=\"detailHeading\">eMail: </span><br /><span class=\"details\">" + student.getEMail() + "</span><br />" +
            "<span class=\"detailHeading\">Program: </span><br /><span class=\"details\">" + student.getProgram() + "</span><br />" +
            "<span class=\"detailHeading\">Phone: </span><br /><span class=\"details\">" + student.getPhoneNumber() + "</span><br />" +
            "<span class=\"detailHeading\">Address: </span><br /><span class=\"details\">" + student.getAddress() + ", " + student.getCity() + "</span><br />" +
            "<span class=\"detailHeading\">Campus: </span><br /><span class=\"details\">" + student.getCampus() + "<br />" +
            "<span class=\"detailHeading\">Aditional Info: </span><br /><span class=\"details\">" + student.getAdditionalInfo() + "</span>";

        StudentMenu.Visible = true;
        Resume.Visible = true;
        StudentContent.InnerHtml = content;

        StuAccount1.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">My Account</a>";
        StuAccount2.InnerHtml = "<a href=\"MyAccount.aspx?eMail=" + eMail + "\">Upload Résumé</a>";

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;
    }

    public void ShowEmployer()
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;
        Resume.Visible = false;

        EmployerMenu.Visible = true;
        EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;
    }

    public void ShowInstructor()
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;
        Resume.Visible = false;

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.Visible = true;
        InstructorContent.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ResumeUpload.HasFile)
        {
            try
            {
                string eMail = Session["eMail"].ToString();

                string fileName = Path.GetFileName(ResumeUpload.PostedFile.FileName);
                string fileExtention = Path.GetExtension(ResumeUpload.PostedFile.FileName);

                int fileSize = ResumeUpload.PostedFile.ContentLength;

                byte[] documentBinary = new byte[fileSize];
                ResumeUpload.PostedFile.InputStream.Read(documentBinary, 0, fileSize);
                                

                if (ResumeDB.FindResume(eMail))
                {
                    //If a resumé is found update the current one                    
                    if (ResumeDB.UpdateResume(eMail, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize) > 0)
                    {
                        string script = "<script type=\"text/javascript\">alert('Resume Sucessfully Uploaded.');</script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                        
                    }
                }
                else
                {
                    //If a resumé is not found a new row is created
                    if (ResumeDB.UploadResume(eMail, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize) > 0)
                    {
                        string script = "<script type=\"text/javascript\">alert('Resume Sucessfully Uploaded.');</script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                    }
                }
                

                
            }
            catch (Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }

        }
    }
}