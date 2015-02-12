using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;

using FinalBL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

public partial class TestingExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Creates New Excel Object
        Excel.Application excelApp = new Excel.ApplicationClass();

        excelApp.Visible = true;

        //Opens an excel workbook
        Excel.Workbook workbook = excelApp.Workbooks.Open("C:\\tester\\Sample.xlsx",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);

        //Opens worksheet in workbook NON-ZERO INDEXED
        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

        //Gets a range of all used cells in worksheet
        Excel.Range range = worksheet.UsedRange;
        
        //Creates an array of all values in range
        object[,] valueArray = (object[,])range.get_Value
            (Excel.XlRangeValueDataType.xlRangeValueDefault);

        int studentsEntered = 0;

        try
        {
            //For all columns in range NON_ZERO INDEXED
            for (int i = 2; i <= range.Rows.Count; i++)
            {
                string email = valueArray[i, 1].ToString();

                if (!AccountDB.FindAccountByEmail(email))
                {

                    string studentID = valueArray[i, 2].ToString();
                    string firstName = valueArray[i, 3].ToString();
                    string lastName = valueArray[i, 4].ToString();
                    string programCode = valueArray[i, 5].ToString();
                    string phone = valueArray[i, 6].ToString();
                    string address = valueArray[i, 7].ToString();
                    string city = valueArray[i, 8].ToString();
                    string campus = valueArray[i, 9].ToString();
                    string additionalInfo = valueArray[i, 10].ToString();                                
                    
                    RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
                    string seedString = "MBILENSKY009";
                    byte[] byteValues = Encoding.Unicode.GetBytes(seedString);
                    rngCSP.GetBytes(byteValues);

                    string password = Convert.ToBase64String(byteValues).Substring(0, 8);
                    
                    studentsEntered += StudentDB.InsertStudent(email, password.GetHashCode().ToString(), studentID, firstName, lastName, programCode,
                        phone, address, city, campus, additionalInfo);

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
        catch (Exception ex)
        {
            string successScript = "<script type=\"text/javascript\">alert('" + ex.Message + " Shit Happened.');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", successScript);
        }

        

        string errorScript = "<script type=\"text/javascript\">alert('" + (studentsEntered / 2) + " Students entered.');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", errorScript);


        //Close and release workbook
        workbook.Close(false, Type.Missing, Type.Missing);
        Marshal.ReleaseComObject(workbook);

        //Close and release Excel
        excelApp.Quit();
        Marshal.FinalReleaseComObject(excelApp);
    }
}