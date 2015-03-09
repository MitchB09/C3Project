using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalBL;
using FinalGUI.StringEncrypt;

public partial class RemovePublicFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["fileId"] != null)
        {
            int fileID = Convert.ToInt32(StringEncryption.Decrypt(Request.QueryString["fileId"]));
            try
            {
                PublicFileDB.RemoveFile(fileID);
                Response.Redirect("Information.aspx");
            }
            catch(Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('Error has occurred.\n" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                Response.Redirect("Information.aspx");
            }
           
        }
        Response.Redirect("Information.aspx");

        
    }
}