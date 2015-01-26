﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Posting
    {
        private int postID;
        private string empEmail;
        private DateTime dateAdded;
        private string jobTitle;
        private string additionalInfo;
        
        //Constructor
        public Posting(int postID, string empEmail, DateTime dateAdded, string additionalInfo)
        {
            setPostID(postID);
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