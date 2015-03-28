using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using FinalBL;
using FinalGUI.StringEncrypt;

public partial class CreateEmployerAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ReturnToLogin(object sender, EventArgs e)
    {
        Server.Transfer("Login.aspx");
    }

    protected void CreateAccount(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = StringEncryption.Encrypt(txtPassword.Text);
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string companyName = txtCompanyName.Text;
        string companyPostition = txtPosition.Text;
        string phoneNumber = txtPhoneNumber.Text;
        string companyAddress = txtCompanyAddress.Text;
        string companyCity = txtCompanyCity.Text;
        string companyProvince = lbProvince.SelectedValue;

        try
        {
            if (!AccountDB.FindAccountByEmail(email))
            {
                if (EmployerDB.SelfCreateEmployer(email, password, firstName, lastName, companyName, companyPostition, phoneNumber, companyAddress, companyCity, companyProvince) == 2)
                {
                    string script = "<script type=\"text/javascript\">alert('Account Successfully Created.');window.location = \"UnvettedEmployers.aspx\";</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('There is already an account with this email.');window.location = \"UnvettedEmployers.aspx\";</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
            
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('Error: " + ex.HResult.ToString() + " Has Occurred.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);                       
        }

         
    }
}