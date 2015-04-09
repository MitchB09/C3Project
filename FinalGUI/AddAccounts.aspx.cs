using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using Excel;
using FinalGUI.ShowMenu;
using FinalGUI.StringEncrypt;
using FinalBL;

public partial class TestingExcel : System.Web.UI.Page
{

    string email = "";
    Regex matchEmail = new Regex("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$");

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
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Employer")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }
        else if (Session["usertype"].ToString() == "Instructor")
        {
            HttpContext.Current.Response.Redirect("LogIn.aspx");            
        }
        else if (Session["usertype"].ToString() == "Admin")
        {
            ShowAdmin(email);            
        }
    }

    protected void AddStudents(object sender, EventArgs e)
    {
        
        if (fulStudentUpload.HasFile && Path.GetExtension(fulStudentUpload.FileName) == ".xlsx")
        {
            int studentsEntered = 0;

            

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fulStudentUpload.FileContent);
            fulStudentUpload.FileContent.Close();

            DataSet result = excelReader.AsDataSet(); 
                    
            try
            {

                foreach (DataTable table in result.Tables)
                {
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        string email = table.Rows[i].ItemArray[0].ToString();
                        

                        if (matchEmail.IsMatch(email) && !AccountDB.FindAccountByEmail(email))
                        {

                            string studentID = table.Rows[i].ItemArray[1].ToString();
                            string firstName = table.Rows[i].ItemArray[2].ToString();
                            string lastName = table.Rows[i].ItemArray[3].ToString();
                            string programCode = table.Rows[i].ItemArray[4].ToString();
                            string phone = table.Rows[i].ItemArray[5].ToString();
                            string address = table.Rows[i].ItemArray[6].ToString();
                            string city = table.Rows[i].ItemArray[7].ToString();
                            string campus = table.Rows[i].ItemArray[8].ToString();
                            string additionalInfo = table.Rows[i].ItemArray[9].ToString();

                            RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
                            string seedString = "MBILENSKY009";
                            byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
                            rngCSP.GetBytes(byteValues);

                            string password = Convert.ToBase64String(byteValues).Substring(0, 8);

                            Student student = new Student(email, StringEncryption.Encrypt(password), studentID, firstName, lastName, programCode,
                                phone, address, city, campus, additionalInfo);

                            studentsEntered += StudentDB.InsertStudent(student);

                            MailMessage mail = new MailMessage();

                            mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
                            mail.To.Add(email);
                            //
                            mail.Subject = "C3 Project Password";
                            mail.Body = "Here is your password: " + password + ".";
                            //
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.EnableSsl = true;
                            smtp.Timeout = 900000;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //
                            smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
                            smtp.Send(mail);


                        }
                    }
                }
                
                excelReader.Close();
             
            }
            catch (Exception ex)
            {
                string successScript = "<script type=\"text/javascript\">alert('Exception: " + ex.Message + ".');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", successScript);
            }



            string errorScript = "<script type=\"text/javascript\">alert('" + (studentsEntered / 2) + " Students entered.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);

            /*

            //Close and release workbook
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.ReleaseComObject(workbook);

            //Close and release Excel
            excelApp.Quit();
            Marshal.FinalReleaseComObject(excelApp);
             * */

            

        }
        else
        {
            string errorScript = "<script type=\"text/javascript\">alert('Either there is no entered file or it is not an excel file.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
        }
    
        
    }

    protected void AddInstructors(object sender, EventArgs e)
    {

        if (fulInstructorUpload.HasFile && Path.GetExtension(fulInstructorUpload.FileName) == ".xlsx")
        {
            int instructorsAdded = 0;

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fulInstructorUpload.FileContent);
            fulInstructorUpload.FileContent.Close();

            DataSet result = excelReader.AsDataSet();

            try
            {

                foreach (DataTable table in result.Tables)
                {
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        string email = table.Rows[i].ItemArray[0].ToString();

                        if (matchEmail.IsMatch(email) && !AccountDB.FindAccountByEmail(email))
                        {
                            Instructor instructor = new Instructor();
                            instructor.setEMail(email);
                            instructor.setFirstName(table.Rows[i].ItemArray[1].ToString());
                            instructor.setLastName(table.Rows[i].ItemArray[2].ToString());
                            instructor.setProgram(table.Rows[i].ItemArray[3].ToString());
                            instructor.setCampus(table.Rows[i].ItemArray[4].ToString());
                            instructor.setContactInfo(table.Rows[i].ItemArray[5].ToString());

                            RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
                            string seedString = "MBILENSKY009";
                            byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
                            rngCSP.GetBytes(byteValues);

                            string password = Convert.ToBase64String(byteValues).Substring(0, 8);

                            instructorsAdded += InstructorDB.InsertInstructor(instructor);

                            MailMessage mail = new MailMessage();

                            mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
                            mail.To.Add(email);
                            //
                            mail.Subject = "C3 Project Password";
                            mail.Body = "Here is your password: " + password + ".";
                            //
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.EnableSsl = true;
                            smtp.Timeout = 300000;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //
                            smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
                            smtp.Send(mail);


                        }
                    }
                }

                excelReader.Close();

            }
            catch (Exception ex)
            {
                string successScript = "<script type=\"text/javascript\">alert('" + ex.Message + " Shit Happened.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", successScript);
            }



            string errorScript = "<script type=\"text/javascript\">alert('" + (instructorsAdded / 2) + " Instructors entered.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);   


        }
        else
        {
            string errorScript = "<script type=\"text/javascript\">alert('Either there is no entered file or it is not an excel file.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
        }
    }

    protected void AddStudentByForm(object sender, EventArgs e)
    {
        
        Student student = new Student();
        student.setEMail(txtEmail.Text);
        student.setStudentID(txtStudentId.Text);
        student.setFirstName(txtFirstName.Text);
        student.setLastName(txtLastName.Text);
        student.setProgram(txtProgramCode.Text);
        student.setCampus(txtCampus.Text);

        RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
        string seedString = "MBILENSKY009";
        byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
        rngCSP.GetBytes(byteValues);

        string password = Convert.ToBase64String(byteValues).Substring(0, 8);

        student.setPassword(StringEncryption.Encrypt(password));

        try
        {
            if (StudentDB.InsertStudent(student) > 0)
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
                mail.To.Add(email);
                //
                mail.Subject = "C3 Project Password";
                mail.Body = "Here is your password: " + password + ".";
                //
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Timeout = 300000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //
                smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
                smtp.Send(mail);

                string errorScript = "<script type=\"text/javascript\">alert('Successfully entered student.');window.location = \"AddAccounts.aspx\";</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
            }
        }
        catch (Exception ex)
        {
            string errorScript = "<script type=\"text/javascript\">alert('An Error occured entering student.\n Error: " + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
        }
        


    }

    protected void AddInstructorByForm(object sender, EventArgs e)
    {

        Instructor instructor = new Instructor();
        instructor.setEMail(txtInstEmail.Text);
        instructor.setFirstName(txtInsFirstName.Text);
        instructor.setLastName(txtInsLastName.Text);
        instructor.setProgram(txtInsProgCode.Text);
        instructor.setCampus(txtInsCampus.Text);
        instructor.setContactInfo(txtContactInfo.Text);      
        

        RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
        string seedString = "MBILENSKY009";
        byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
        rngCSP.GetBytes(byteValues);

        string password = Convert.ToBase64String(byteValues).Substring(0, 8);

        instructor.setPassword(StringEncryption.Encrypt(password));

        try
        {
            if (InstructorDB.InsertInstructor(instructor) > 0)
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("C3ProjectNBCC@gmail.com");
                mail.To.Add(email);
                //
                mail.Subject = "C3 Project Password";
                mail.Body = "Here is your password: " + password + ".";
                //
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Timeout = 300000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //
                smtp.Credentials = new NetworkCredential("C3ProjectNBCC@gmail.com", "Jack & Jill");
                smtp.Send(mail);

                string errorScript = "<script type=\"text/javascript\">alert('Successfully Entered Instructor.');window.location = \"AddAccounts.aspx\";</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
            }
        }
        catch (Exception ex)
        {
            string errorScript = "<script type=\"text/javascript\">alert('An Error occured entering Instructor.\n Error: " + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);
        }



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