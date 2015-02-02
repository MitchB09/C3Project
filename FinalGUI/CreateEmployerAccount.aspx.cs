using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalBL;

public partial class CreateEmployerAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateAccount(object sender, EventArgs e)
    {
        string eMail = txtEMail.Text;
        string password = txtPassword.Text.GetHashCode().ToString();
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string companyName = txtCompanyName.Text;
        string companyPostition = txtPosition.Text;
        string phoneNumber = txtPhoneNumber.Text;
        string companyAddress = txtCompanyAddress.Text;
        string companyCity = txtCompanyCity.Text;
        string companyProvince = lbProvince.SelectedValue;

        int created = EmployerDB.SelfCreateEmployer(eMail, password, firstName, lastName, companyName, companyPostition, phoneNumber, companyAddress, companyCity, companyProvince);

        string script = "<script type=\"text/javascript\">alert('" + created + "');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);   
    }
}