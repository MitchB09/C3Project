using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Practicum
    {
        private int practicumID;
        private int postID;
        private string stuEmail;
        private string empEmail;
        private DateTime dateAdded;
        private string company;
        private string contact;
        private string additionalDetails;

        public Practicum()
        {
            //
        }

        //Getters
        public int getPracticumID()
        {
            return this.practicumID;
        }
        public int getPostID()
        {
            return this.postID;
        }
        public string getStuEmail()
        {
            return this.stuEmail;
        }
        public string getEmpEmail()
        {
            return this.empEmail;
        }
        public DateTime getDateAdded()
        {
            return this.dateAdded;
        }
        public string getCompany()
        {
            return this.company;
        }
        public string getContact()
        {
            return this.contact;
        }
        public string getAddDetails()
        {
            return this.additionalDetails;
        }

        //Setters
        public void setPracticumID(int practicumID)
        {
            this.practicumID = practicumID;
        }
        public void setPostID(int postID)
        {
            this.postID = postID;
        }
        public void setStuEmail(string stuEmail)
        {
            this.stuEmail = stuEmail;
        }
        public void setEmpEmail(string empEmail)
        {
            this.empEmail = empEmail;
        }
        public void setDateAdded(DateTime date)
        {
            this.dateAdded = date;
        }
        public void setCompany(string company)
        {
            this.company = company;
        }
        public void setContact(string contact)
        {
            this.contact = contact;
        }
        public void setAddDetails(string additionalDetails)
        {
            this.additionalDetails = additionalDetails;
        }
    }
}
