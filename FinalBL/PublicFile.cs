using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class PublicFile
    {
        private int fileId;
        private string fileName;
        private string fileType;
        private DateTime dateAdded;
        private byte[] fileData;

        //Constructor
        public PublicFile(int fileId, string fileName, string fileType, DateTime dateAdded, byte[] gileData)
        {
            setFileId(fileId);
            setFileName(fileName);
            setFileType(fileType);
            setDateAdded(dateAdded);
            setFileData(fileData);
        }

        public PublicFile()
        {
            //Blank COnstuctor
        }

        //Getters       
        public int getFileId()
        {
            return this.fileId;
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
        public byte[] getFileData()
        {
            return this.fileData;
        }
    
        //Setters        
        public void setFileId(int fileId)
        {
            this.fileId = fileId;
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
        public void setFileData(byte[] fileData)
        {
            this.fileData = fileData;
        }
    }
}
