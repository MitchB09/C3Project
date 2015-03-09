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
using FinalGUI.StringEncrypt;
using FinalGUI.ShowMenu;

public partial class UnvettedEmployers : System.Web.UI.Page
{
    string email = "";
    int page = 1;

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

        if (Request.QueryString["page"] != null)
        {
            try
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            catch
            {
                page = 1;
            }
        }

        //Redirects if no usertype is present (i.e. no one is signed in)
        if (Session["usertype"].ToString() != "Instructor")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }        
        else
        {
            ShowInstructor(email);
            ShowContent(page);
        }


    }
        

    public void ShowContent(int pageNum)
    {
        List<Employer> UnvettedList = new List<Employer>();

        try
        {
            UnvettedList = EmployerDB.UnvettedEmployers(pageNum);

            string content = "";

            if (UnvettedList.Count == 0)
            {
                content += "There are currently no unvetted employers to view";
            }
            else 
            {
                //For each posting in list for this page(i.e. page 1 is postings 1 to 5)
                foreach (Employer employer in UnvettedList)
                {
                    content += "<div class=\"employer\"><a href=\"UnvettedDetails.aspx?empEMail=" + StringEncryption.Encrypt(employer.getEMail()) + "\">" + employer.getCompanyName() + "</a><br />" + employer.getFirstName() + " " + employer.getLastName() + "<br />" + employer.getEMail() + "</div><hr />";
                }

                //Start div for pageListing
                content += "<div id=\"pageListing\">";

                //If the page number is greater then 1 add a left arrow.
                if (pageNum > 1)
                {
                    content += "<a href=\"UnvettedEmployers.aspx?page=" + (pageNum - 1) + "\"><img src=\"images/LeftArrow.png\" height=\"12px\" width=\"12px\"/></a>";
                }

                //add current page number of total page number
                content += "&nbsp;Page " + pageNum + " of " + (int)Math.Ceiling((double)EmployerDB.UnvettedEmployersCount() / 5) + "&nbsp;";

                //If current page is less than total count page add a right arrow.
                if (pageNum < (int)Math.Ceiling((double)EmployerDB.UnvettedEmployersCount() / 5))
                {
                    content += "<a href=\"UnvettedEmployers.aspx?page=" + (pageNum + 1) + "\"><img src=\"images/RightArrow.png\" height=\"12px\" width=\"12px\"/></a>";
                }

                //end div for pageListing
                content += "</div>";
            }
            
            Content.InnerHtml = content;
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('" + ex + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }


    public void ShowInstructor(string email)
    {
        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        //InstructorContent.Visible = true;
    }
}