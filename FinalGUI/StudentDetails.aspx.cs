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
using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;

public partial class StudentDetails : System.Web.UI.Page
{
    string email = "";

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

        email = StringEncryption.Decrypt(Request.QueryString["email"]);

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
            ShowResume(email);
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);
            ShowResume(email);
        }

        


        
        try
        {
            Student student = StudentDB.StudentByEMail(email);


            string studentName = student.getFirstName() + " " + student.getLastName();
            string studentEMail = student.getEMail();
            string studentProgram = student.getProgram();
            string studentInfo = student.getAdditionalInfo();

            Resume foundResume = ResumeDB.GetResumeName(email);

            string content = studentName + "<br />" + studentEMail + "<br />" + studentProgram + "<br />" + studentInfo + " <br / >";
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
            email = StringEncryption.Decrypt(Request.QueryString["email"]);

            Resume foundResume = ResumeDB.GetResume(email);
            
            if (foundResume.getFileType() == ".pdf")
            {
                Response.Clear();

                //intermet media type for a .pdf file
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(foundResume.getDocData());
                Response.End();
            }
            else if (foundResume.getFileType() == ".docx")
            {
                Response.Clear();

                //intermet media type for a .docx file
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("content-disposition", @"attachment;filename=" + foundResume.getFileName() + "");
                Response.BinaryWrite(foundResume.getDocData());
                
                Response.End();
            }
            else if (foundResume.getFileType() == ".doc")
            {
                Response.Clear();

                //intermet media type for a .doc file
                Response.ContentType = "application/msword";
                Response.BinaryWrite(foundResume.getDocData());
                Response.End();
            }
            
        }
        catch(Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
        
    }

    public void ShowStudent(string email)
    {
        ResumeDiv.Visible = false;

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

        EmployerMenu.Visible = true;
        //EmployerContent.Visible = true;

        InstructorMenu.InnerHtml = ShowMenu.ShowEmployer(email);
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