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
            UnknownMenu.Visible = true;
            StudentMenu.Visible = false;
            EmployerMenu.Visible = false;
            InstructorMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Student")
        {
            UnknownMenu.Visible = false;
            StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
            EmployerMenu.Visible = false;
            InstructorMenu.Visible = false;
            AdminMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            UnknownMenu.Visible = false;
            EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
            StudentMenu.Visible = false;            
            InstructorMenu.Visible = false;
            AdminMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            UnknownMenu.Visible = false;
            InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
            StudentMenu.Visible = false;
            EmployerMenu.Visible = false;
            AdminMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            UnknownMenu.Visible = false;
            InstructorMenu.Visible = false;
            StudentMenu.Visible = false;
            EmployerMenu.Visible = false;
            AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);
            AdminContols.Visible = true;
        }

        try
        {
            List<PublicFile> fileList = PublicFileDB.GetPublicFiles();

            string content = "";

            foreach(PublicFile file in fileList)
            {
                content += "<a href=\"InfoDetails.aspx?fileId=" + StringEncryption.Encrypt(file.getFileId().ToString()) + "\" target=\"_blank\">"
                    + file.getFileName().Replace('_', ' ') + "</a><br />";
            }

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
                    /*if (ResumeDB.FindResume(email))
                    {
                        //If a resumé is found update the current one                    
                        if (ResumeDB.UpdateResume(email, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize) > 0)
                        {
                            string script = "<script type=\"text/javascript\">alert('Resume Sucessfully Uploaded.');</script>";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);

                        }
                    }
                    else 
                    { */
                        //If a resumé is not found a new row is created
                        if (PublicFileDB.UploadFile(fileName, fileExtention, System.DateTime.Now, documentBinary) > 0)
                        {
                            string script = "<script type=\"text/javascript\">alert('File Sucessfully Uploaded.');</script>";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                        }
                    //}
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
    
}