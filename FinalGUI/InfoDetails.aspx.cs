using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InfoDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string form = Request.QueryString["form"];

        try
        {
            Response.Clear();
            string filePath = "Add_Docs/" + form;
            Response.ContentType = "application/pdf";
            Response.WriteFile(filePath);
            Response.End();

        }
        catch (Exception ex)
        {
            form1.InnerHtml = "Shit Fucked Up." + ex.Message;
        }
    }
}