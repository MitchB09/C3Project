using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FinalBL;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;

public partial class UnvettedDetails : System.Web.UI.Page
{
    string empEMail = "";
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

        if (Request.QueryString["empEmail"] != null)
        {
            empEMail = StringEncryption.Decrypt(Request.QueryString["empEMail"]);            
        }

        //Redirects if no usertype is present (i.e. no one is signed in)
        if (Session["usertype"].ToString() != "Instructor")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else
        {
            ShowInstructor(email);
            ShowContent(empEMail);
        }
    }

    public void ShowContent(string empEMail)
    {
        string content = "";

        try
        {
            Employer unvettedEmployer = new Employer();
            unvettedEmployer = EmployerDB.EmployerByEMail(empEMail);

            content = unvettedEmployer.getCompanyName() + "<br /><br />" + unvettedEmployer.getFullName() + "<br />" + unvettedEmployer.getCompanyPosition() + "<br />" + unvettedEmployer.getCompanyAddress() + " " + unvettedEmployer.getCompanyCity() + ", " + unvettedEmployer.getCompanyProvince() +
                "<br />" + "Phone: " + unvettedEmployer.getPhoneNumber() + "<br />email: " + unvettedEmployer.getEMail();

            EmployerDetails.InnerHtml = content;
        }
        catch
        {
            content = "An Error Has Occured";
            EmployerDetails.InnerHtml = content;
        }
        
    }

    public void ShowInstructor(string email)
    {
        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        //InstructorContent.Visible = true;
    }


    protected void Approve(object sender, EventArgs e)
    {
        if (EmployerDB.ApproveEmployer(empEMail) > 0)
        {
            //Shows successful approval and then redirects to listing page
            string script = "<script type=\"text/javascript\">alert('Successfully Approved Employer.');window.location = \"UnvettedEmployers.aspx\";</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
                        
        }
        else
        {
            string script = "<script type=\"text/javascript\">alert('An Error Has Occurred.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);            
        }
        
    }

    protected void Reject(object sender, EventArgs e)
    {
        //Move Employer to new table?
    }

    protected void Redirect()
    {
        HttpContext.Current.Response.Redirect("UnvettedEmployers.aspx");
    }
}