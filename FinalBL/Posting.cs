using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalBL
{
    public class Posting : Employer
    {
        private int postID;
        private string empEmail;
        private string company;
        private string contact;
        private DateTime dateAdded;
        private string jobTitle;
        private string additionalInfo;
        
        //Constructor
        public Posting(int postID, string contact, string empEmail, DateTime dateAdded, string additionalInfo, string eMail, string password, string firstName, string lastName, string companyName, string companyPosition, 
            string phoneNumber, string companyAddress, string companyCity, string companyProvince, bool approvedEmployer)
            :base(eMail, password, firstName, lastName, companyName, companyPosition, 
            phoneNumber, companyAddress, companyCity, companyProvince, approvedEmployer)
        {
            setPostID(postID);
            setCompany(companyName);
            setContact(contact);
            setEmpEmail(empEmail);
            setDateAdded(dateAdded);
            setAdditionalInfo(additionalInfo);
        }

        public Posting()
        { }
        
        //Getters
        public int getPostID()
        {
            return this.postID;
        }
        public string getEmpEmail()
        {
            return this.empEmail;
        }
        public string getCompany()
        {
            return this.company;
        }
        public string getContact()
        {
            return this.contact;
        }        
        public DateTime getDateAdded()
        {
            return this.dateAdded;
        }
        public string getJobTitle()
        {
            return this.jobTitle;
        }
        public string getAdditionalInfo()
        {
            return this.additionalInfo;
        }

        //Setters
        public void setPostID(int postID)
        {
            this.postID = postID;
        }
        public void setEmpEmail(string empEmail)
        {
            this.empEmail = empEmail;
        }
        public void setCompany(string company)
        {
            this.company = company;
        }
        public void setContact(string contact)
        {
            this.contact = contact;
        }
        public void setDateAdded(DateTime dateAdded)
        {
            this.dateAdded = dateAdded;
        }
        public void setJobTitle(string jobTitle)
        {
            this.jobTitle = jobTitle;
        }
        public void setAdditionalInfo(string additionalInfo)
        {
            this.additionalInfo = additionalInfo;
        }
    }
}
