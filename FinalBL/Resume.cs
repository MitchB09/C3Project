using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Resume
    {
        private string eMail;
        private string fileName;
        private string fileType;
        private DateTime dateAdded;
        private byte[] docData;

        //Constructor
        public Resume(string eMail, DateTime dateAdded, byte[] docData)
        {
            setEMail(eMail);
            setDateAdded(dateAdded);
            setDocData(docData);
        }

        public Resume()
        {
            //Blank COnstuctor
        }

        //Getters
        public string getEMail()
        {
            return this.eMail;
        }
        public string getFileName()
        {
            return this.fileName;
        }
        public string getFileType()
        {
            return this.fileType;
        }
        public DateTime getDateAdded()
        {
            return this.dateAdded;
        }
        public byte[] getDocData()
        {
            return this.docData;
        }
    
        //Setters
        public void setEMail(string eMail)
        {
            this.eMail = eMail;
        }
        public void setFileName(string fileName)
        {
            this.fileName = fileName;
        }
        public void setFileType(string fileType)
        {
            this.fileType = fileType;
        }
        public void setDateAdded(DateTime dateAdded)
        {
            this.dateAdded = dateAdded;
        }
        public void setDocData(byte[] docData)
        {
            this.docData = docData;
        }
    }
}
