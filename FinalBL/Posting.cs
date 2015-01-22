using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Posting
    {
        private string postID;
        private string empEmail;
        private DateTime dateAdded;
        private string additionalInfo;
        
        //Constructor
        public Posting(string postID, string empEmail, DateTime dateAdded, string additionalInfo)
        {
            setPostID(postID);
            setEmpEmail(empEmail);
            setDateAdded(dateAdded);
            setAdditionalInfo(additionalInfo);
        }
        
        //Getters
        public string getPostID()
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
        public string getAdditionalInfo()
        {
            return this.additionalInfo;
        }

        //Setters
        public void setPostID(string postID)
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
        public void setAdditionalInfo(string additionalInfo)
        {
            this.additionalInfo = additionalInfo;
        }
    }
}
