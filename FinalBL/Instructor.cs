using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Instructor : Account
    {
        private string firstName;
        private string lastName;
        private string program;
        private string campus;
        private string contactInfo;

        //Constructors
        public Instructor(string eMail, string password, string firstName, string lastName, string program,
            string campus, string contactInfo)
            : base(eMail, password, "Instructor")
        {
            setFirstName(firstName);
            setLastName(lastName);
            setProgram(program);
            setCampus(campus);
            setContactInfo(contactInfo);
        }
            

        //Getters
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getProgram()
        {
            return this.program;
        }
        public string getCampus()
        {
            return this.campus;
        }
        public string getContactInfo()
        {
            return this.contactInfo;
        }

        //Setters
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
        public void setCampus(string campus)
        {
            this.campus = campus;
        }
        public void setContactInfo(string contactInfo)
        {
            this.contactInfo = contactInfo;
        }
    }
}
