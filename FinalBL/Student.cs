using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Student : Account
    {
        private string studentID;
        private string firstName;
        private string lastName;
        private string program;
        private string phoneNumber;
        private string address;
        private string city;
        private string campus;
        private string additionalInfo;

        //Constructors
        public Student(string eMail, string password, string studentID, string firstName, string lastName, string program, 
            string phoneNumber, string address, string city, string campus, string additionalInfo)
            :base(eMail, password, "Student")
        {
            setStudentID(studentID);
            setFirstName(firstName);
            setLastName(lastName);
            setProgram(program);
            setPhoneNumber(phoneNumber);
            setAddress(address);
            setCity(city);
            setCampus(campus);
            setAdditionalInfo(additionalInfo);
        }

        public Student()
        {

        }
            

        //Getters
        public string getStudentID()
        {
            return this.studentID;
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getFullName()
        {
            return this.firstName + " " + this.lastName;
        }
        public string getProgram()
        {
            return this.program;
        }
        public string getPhoneNumber()
        {
            if (this.phoneNumber == String.Empty || this.phoneNumber == null)
            {
                return "N/A";
            }
            else
            {
                return this.phoneNumber;
            }                
        }
        public string getAddress()
        {
            if (this.address == String.Empty || this.address == null)
            {
                return "N/A";
            }
            else
            {
                return this.address;
            }
        }
            
        public string getCity()
        {
            if (this.city == String.Empty || this.city == null)
            {
                return "N/A";
            }
            else
            {
                return this.city;
            }
        }
        public string getCampus()
        {
            return this.campus;
        }
        public string getAdditionalInfo()
        {
            if (this.additionalInfo == String.Empty || this.additionalInfo == null)
            {
                return "N/A";
            }
            else
            {
                return this.additionalInfo;
            }
        }

        //Setters
        public void setStudentID(string studentID)
        {
            this.studentID = studentID;
        }
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public void setProgram(string program)
        {
            this.program = program;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;                      
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public void setCampus(string campus)
        {
            this.campus = campus;
        }
        public void setAdditionalInfo(string additionalInfo)
        {
            this.additionalInfo = additionalInfo;
        }
    }
}
