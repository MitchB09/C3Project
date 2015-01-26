using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateEmployerAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateAccount(object sender, EventArgs e)
    {
        string eMail = txtEMail.Text;
        string password = txtPassword.Text;
        string firstName = txtFirstName.Text;

        string script = "<script type=\"text/javascript\">alert('An Error Has Occurred.');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);    
    }
}