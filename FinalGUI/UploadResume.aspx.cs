﻿using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalBL;

public partial class UploadResume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || Session["usertype"].ToString() != "Student")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
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

                int result = ResumeDB.UploadResume(eMail, fileName, fileExtention, System.DateTime.Now, documentBinary, fileSize);

                string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + result +"');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
            catch (Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }

        }
    }
}