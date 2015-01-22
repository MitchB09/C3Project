﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using FinalBL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void LogIn(object sender, EventArgs e)
    {
        
        string user = username.Text;
        string pass = password.Text;
        //HashAlgorithm algorithm = SHA1.Create();
        string hashPass = pass.GetHashCode().ToString();

        Account result = new Account();

        try
        {
            result = AccountDB.LogIn(user, hashPass);

            if (result != null)
            {
                //Account userInfo = new Account(result.getEMail(), null, result.getAccountType());
                Session["eMail"] = result.getEMail();
                Session["usertype"] = result.getAccountType();
                HttpContext.Current.Response.Redirect("Home.aspx");
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('eMail or password is incorrect " + hashPass.ToString() + "');</script>";
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