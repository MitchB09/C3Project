using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalGUI.ShowMenu;

public partial class Admin : System.Web.UI.Page
{
    string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks if the is an email stored in the session if not returns to LogIn.aspx
        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }
        else
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }

        //Checks which type user is if none return to LigIn.aspx
        if (Session["usertype"] == null)
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);
        }
    }




    void ShowAdmin(string email)
    {
        AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);
    }

}