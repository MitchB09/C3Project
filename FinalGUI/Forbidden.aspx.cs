﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forbidden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();

        form1.InnerHtml = ex.Message;
    }
}