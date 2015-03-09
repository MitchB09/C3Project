using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalGUI.ShowMenu;
using FinalBL;

public partial class UploadPracticum : System.Web.UI.Page
{

    string email = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] != null)
        {
            email = Session["email"].ToString();
        }
        else
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }              

        //Redirects if no usertype is present (i.e. no one is signed in)
        if (Session["usertype"] == null)
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Student")
        {
            ShowStudent(email);
            
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            ShowEmployer(email);

        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            ShowInstructor(email);            
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);            
        }
    }
    
    protected void SourceChange(object sender, EventArgs e)
    {
        if (rbPostID.Checked)
        {
            txtPostID.Enabled = true;
            txtCompanyName.Enabled = false;
            txtContactName.Enabled = false;
            txtContactEMail.Enabled = false;            
            txtAddDetails.Enabled = false;            
        }
        else if(rbEmp.Checked)
        {
            txtPostID.Enabled = false;
            txtCompanyName.Enabled = true;
            txtContactName.Enabled = true;
            txtContactEMail.Enabled = true;            
            txtAddDetails.Enabled = true;            
        }
    }
    
    protected void SubmitPracticum(object sender, EventArgs e)
    {
        if (rbPostID.Checked)
        {
            try
            {
                int postID = Convert.ToInt32(txtPostID.Text);
                Posting post = PostingDB.GetPostingByPostID(postID);

                if (PostingDB.PostingExists(postID))
                {
                    Practicum practicum = new Practicum();
                    practicum.setStuEmail(email);
                    practicum.setPostID(postID);
                    practicum.setDateAdded(System.DateTime.Now.Date);

                    PracticumDB.insertPracticum(practicum);

                    string script = "<script type=\"text/javascript\">alert('Practicum Is Now Pending Approval.');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }
                else
                {
                    string script = "<script type=\"text/javascript\">alert('Posting does not exist or has been removed.');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }
                

            }
            catch(FormatException)
            {
                string script = "<script type=\"text/javascript\">alert('Post ID must be a number.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
            catch(Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('An Error has occured." + ex.Message + ".');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }
        }
        else if(rbEmp.Checked)
        {
            try
            {
                Practicum practicum = new Practicum();
                practicum.setStuEmail(email);
                practicum.setEmpEmail(txtContactEMail.Text);
                practicum.setCompany(txtCompanyName.Text);
                practicum.setContact(txtContactName.Text);
                practicum.setAddDetails(txtAddDetails.Text);
                practicum.setDateAdded(System.DateTime.Now.Date);

                PracticumDB.insertPracticum(practicum);

                string script = "<script type=\"text/javascript\">alert('Practicum Is Now Pending Approval.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);

            }
            catch (Exception ex)
            {
                string script = "<script type=\"text/javascript\">alert('An Error has occured." + ex.Message + ".');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
            }

        }
    }


    public void ShowStudent(string email)
    {
        StudentMenu.InnerHtml = ShowMenu.ShowStudent(email);

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        // InstructorContent.Visible = false;

        AdminMenu.Visible = false;
    }

    public void ShowEmployer(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.InnerHtml = ShowMenu.ShowEmployer(email);
        //EmployerContent.Visible = true;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = false;

        AdminMenu.Visible = false;
    }

    public void ShowInstructor(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.InnerHtml = ShowMenu.ShowInstructor(email);
        //InstructorContent.Visible = true;

        AdminMenu.Visible = false;
    }

    public void ShowAdmin(string email)
    {
        StudentMenu.Visible = false;
        //StudentContent.Visible = false;

        EmployerMenu.Visible = false;
        //EmployerContent.Visible = false;

        InstructorMenu.Visible = false;
        //InstructorContent.Visible = true;

        AdminMenu.InnerHtml = ShowMenu.ShowAdmin(email);
    }

    
}