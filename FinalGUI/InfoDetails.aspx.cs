using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalBL;
using FinalGUI.StringEncrypt;

public partial class InfoDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fileId = StringEncryption.Decrypt(Request.QueryString["fileID"]);

        PublicFile file = new PublicFile();
        

        try
        {
            file = PublicFileDB.GetPublicFileById(Convert.ToInt32(fileId));

            if(file.getFileType() == ".pdf")
            
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(file.getFileData());
                Response.End();
            }
            

        }
        catch (Exception ex)
        {
            form1.InnerHtml = "Shit Fucked Up." + ex.Message;
        }
    }
}