using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using FinalGUI;

public partial class Information : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null)
        {
            StudentMenu.Visible = false;
            EmployerMenu.Visible = false;
            InstructorMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Student")
        {
            StudentMenu.Visible = true;
            EmployerMenu.Visible = false;
            InstructorMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            EmployerMenu.Visible = true;
            StudentMenu.Visible = false;            
            InstructorMenu.Visible = false;
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            InstructorMenu.Visible = true;
            StudentMenu.Visible = false;
            EmployerMenu.Visible = false;
        }
    }
    
}