using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography;
using FinalBL;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void SendEmail(object sender, EventArgs e)
    {
        try
        {

            string email = "";
            email = txtUsername.Text;
            if (AccountDB.FindAccountByEmail(email))
            {
                RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
                string seedString = "MBILENSKY009";
                byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
                rngCSP.GetBytes(byteValues);

                string newPasswd = Convert.ToBase64String(byteValues).Substring(0, 8);

                if (AccountDB.UpdatePassword(email, newPasswd.GetHashCode().ToString()) > 0)
                {
                    //Both of these links aided in making this code
                    //support.google.com/mail/answer/13287
                    //social.msdn.microsoft.com/Forums/en-US/e018630c-6763-45d5-a43c-76a792e6b8a2/how-to-send-email-from-smtp-gmail-server
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
                    mail.To.Add(email);
                    //
                    mail.Subject = "C3 Project Reset Password";
                    mail.Body = "Here is your new password: " + newPasswd + ".";
                    //
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Timeout = 300000;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //
                    smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
                    smtp.Send(mail);

                    string script = "<script type=\"text/javascript\">alert('An email has been sent.');window.location=\"LogIn.aspx\";</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }                          
                                
            }
            else
            {
                string script = "<script type=\"text/javascript\">alert('No account with supplied email is on record.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }

            
        }
        catch (Exception ex)
        {
            string script = "<script type=\"text/javascript\">alert('Error has occured. " + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }
    }
}