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
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class MyAccount : System.Web.UI.Page
{
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateContent.Visible = false;

        //Checks if the is an email stored in the session
        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }
        else
        {
            email = String.Empty;
        }
        
        if (Session["usertype"].ToString() == "Employer")
        {
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        else if (Session["usertype"] == null || Server.UrlDecode(StringEncryption.Decrypt(Request.QueryString["email"])) != email)
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Student")
        {
            ShowStudent(email);
        }
        

    }

    public void ShowStudent(string email)
    {
        Student student = new Student();
        student = StudentDB.StudentByEMail(email);

        string content = "<h1>" + student.getFullName() + "</h1><br />" +
            "<span class=\"detailHeading\">email: </span><br /><span class=\"details\">" + student.getEMail() + "</span><br />" +
            "<span class=\"detailHeading\">Program: </span><br /><span class=\"details\">" + student.getProgram() + "</span><br />" +
            "<span class=\"detailHeading\">Phone: </span><br /><span class=\"details\">" + student.getPhoneNumber() + "</span><br />" +
            "<span class=\"detailHeading\">Address: </span><br /><span class=\"details\">" + student.getAddress() + ", " + student.getCity() + "</span><br />" +
            "<span class=\"detailHeading\">Campus: </span><br /><span class=\"details\">" + student.getCampus() + "<br />" +
            "<span class=\"detailHeading\">Aditional Info: </span><br /><span class=\"details\">" + Server.HtmlEncode(student.getAdditionalInfo()) + "</span>";

        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
        Resume.Visible = true;
        StudentContent.InnerHtml = content;        

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;
    }

    public void ShowStudentUpdate(string email) 
    {
        StudentContent.Visible = false;
        UpdateContent.Visible = true;
        Resume.Visible = false;

        Student student = new Student();
        student = StudentDB.StudentByEMail(email);

        txtName.InnerText = student.getFullName();
        txtEmail.Text = student.getEMail();
        txtProgram.Text = student.getProgram();
        txtPhone.Text = student.getPhoneNumber();
        txtAddress.Text = student.getAddress();
        txtCity.Text = student.getCity();
        txtCampus.Text = student.getCampus();
        txtAdditionalInfo.Text = student.getAdditionalInfo();
        
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;
        Resume.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        InstructorContent.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        StudentContent.Visible = false;
        Resume.Visible = false;

        EmployerMenu.Visible = false;
        EmployerContent.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        InstructorContent.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ResumeUpload.HasFile)
        {
            try
            {
                string email = Session["email"].ToString();

                string fileName = Path.GetFileName(ResumeUpload.PostedFile.FileName);
                string fileExtention = Path.GetExtension(ResumeUpload.PostedFile.FileName);

                int fileSize = ResumeUpload.PostedFile.ContentLength;

                byte[] documentBinary = new byte[fileSize];
                ResumeUpload.PostedFile.InputStream.Read(documentBinary, 0, fileSize);

                if (fileExtention == ".docx" || fileExtention == ".doc" || fileExtention == ".pdf")
                {
                    if (ResumeDB.FindResume(email))
                    {
                        //If a resumé is found update the current one                    
                        if (ResumeDB.UpdateResume(email, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize) > 0)
                        {
                            string script = "<script type=\"text/javascript\">alert('Resume Sucessfully Uploaded.');</script>";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);

                        }
                    }
                    else
                    {
                        //If a resumé is not found a new row is created
                        if (ResumeDB.UploadResume(email, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize) > 0)
                        {
                            string script = "<script type=\"text/javascript\">alert('Resume Sucessfully Uploaded.');</script>";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                        }
                    }
                }
                else
                {
                    string script = "<script type=\"text/javascript\">alert('Résumé must be a \".pdf\", \".docx\", or a \".doc\" type file');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }
                
                

                
            }
            catch (Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }

        }
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {        
        ShowStudentUpdate(email);
    }

    protected void UpdateStudent(object sender, EventArgs e)
    {
        string phoneNumber = txtPhone.Text.ToString();
        string address = txtAddress.Text.ToString();
        string city = txtCity.Text.ToString();
        string additionalInfo = txtAdditionalInfo.Text.ToString();

        try
        {
            if (StudentDB.SelfUpdateStudent(email, phoneNumber, address, city, additionalInfo) > 0)
            {
                string script = "<script type=\"text/javascript\">alert('Account Successfully Updated.');window.location=\"MyAccount.aspx?email=" + Server.UrlEncode(StringEncryption.Encrypt(email)) + "\";</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('Account Did Not Update.');window.location=\"MyAccount.aspx?email=" + Server.UrlEncode(StringEncryption.Encrypt(email)) + "\";</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('An error has occured." + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
        
    }
}