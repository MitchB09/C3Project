using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

using FinalBL;
using FinalGUI;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class Information : System.Web.UI.Page
{
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminContols.Visible = false;

        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }

        if (Session["usertype"] == null)
        {
            ShowUnknown();
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
            List<PublicFile> fileList = PublicFileDB.GetPublicFiles();

            string content = "";

            foreach(PublicFile file in fileList)
            {
                content += "<a href=\"InfoDetails.aspx?fileId=" + StringEncryption.Encrypt(file.getFileId().ToString()) + "\" target=\"_blank\">"
                    + file.getFileName().Replace('_', ' ') + "</a>";

                if (Session["usertype"] != null && Session["usertype"].ToString() == "Admin")
                {

                    content += "<a class=\"removeText\" href=\"RemovePublicFile.aspx?fileId=" + StringEncryption.Encrypt(file.getFileId().ToString()) + "\">Remove</a>";
                }

                content += "<br />";
           
            }

            content += "<br />";

            listOfPublicFiles.InnerHtml = content;
                
        }
        catch (Exception ex) 
        {
            string script = "<script type=\"text/javascript\">alert('" + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }

    }    

    protected void SubmitFile(object sender, EventArgs e)
    {
        if (UploadFile.HasFile)
        {
            try
            {
                string email = Session["email"].ToString();

                string fileName = Path.GetFileName(UploadFile.PostedFile.FileName);
                string fileExtention = Path.GetExtension(UploadFile.PostedFile.FileName);

                int fileSize = UploadFile.PostedFile.ContentLength;

                byte[] documentBinary = new byte[fileSize];
                UploadFile.PostedFile.InputStream.Read(documentBinary, 0, fileSize);

                if (fileExtention == ".docx" || fileExtention == ".doc" || fileExtention == ".pdf")
                {                    
                    if (PublicFileDB.UploadFile(fileName, fileExtention, System.DateTime.Now, documentBinary) > 0)
                    {
                        string script = "<script type=\"text/javascript\">alert('File Sucessfully Uploaded.');</script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                        Response.Redirect("Information.aspx");
                    }
                    
                }
                else
                {
                    string script = "<script type=\"text/javascript\">alert('File must be a \".pdf\", \".docx\", or a \".doc\" type file');</script>";
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
    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);

        EmployerMenu.Visible = false;

        InstructorMenu.Visible = false;

        AdminMenu.Visible = false;

        UnknownMenu.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);

        InstructorMenu.Visible = false;

        AdminMenu.Visible = false;

        UnknownMenu.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;

        EmployerMenu.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);

        AdminMenu.Visible = false;

        UnknownMenu.Visible = false;
    }

    public void ShowAdmin(string email)
    {
        StudentMenu.Visible = false;

        EmployerMenu.Visible = false;

        InstructorMenu.Visible = false;

        AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);

        UnknownMenu.Visible = false;
    }

    public void ShowUnknown()
    {
        StudentMenu.Visible = false;

        EmployerMenu.Visible = false;

        InstructorMenu.Visible = false;

        AdminMenu.Visible = false;

        UnknownMenu.InnerHtml = ShowMenu.ShowUnknown();
    }
    
}