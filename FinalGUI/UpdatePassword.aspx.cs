using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalBL;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class UpdatePassword : System.Web.UI.Page
{
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        

        //Checks if the is an email stored in the session
        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }
        else
        {
            email = String.Empty;
        }

        if (Session["usertype"] == null)
        {
            throw new HttpException(403, "You must be logged.");
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

    }

    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);
        EmployerMenu.Visible = false;
        InstructorMenu.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        EmployerMenu.Visible = true;
        
        InstructorMenu.Visible = false;
        
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        
        EmployerMenu.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        
    }
    protected void Update(object sender, EventArgs e)
    {
        try
        {
            //If the old password matched the database entry
            if (AccountDB.LogInAttempt(email, StringEncryption.Encrypt(psdOldPassword.Text)))
            {
                //If the update makes a change to the table
                if (AccountDB.UpdatePassword(email, StringEncryption.Encrypt(psdNewPassword.Text)) > 0)
                {
                    string script = "<script type=\"text/javascript\">alert('Account Updated');window.location=\"MyAccount.aspx?email=" + StringEncryption.Encrypt(email) + "\"</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script); 
                }
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('Old password is incorrect.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script); 
            }
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script); 
        }
    }
}