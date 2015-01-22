using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Employer : Account
    {
        private string firstName;
        private string lastName;
        private string companyName;
        private string companyPosition;
        private string phoneNumber;
        private string companyAddress;
        private string companyCity;
        private string companyProvince;
        private bool approvedEmployer;

        //Constructors
        public Employer(string eMail, string password, string firstName, string lastName, string companyName, string companyPosition, 
            string phoneNumber, string companyAddress, string companyCity, string companyProvince, bool approvedEmployer)
            :base(eMail, password, "Employer")
        {
            setFirstName(firstName);
            setLastName(lastName);
            setCompanyName(companyName);
            setPhoneNumber(phoneNumber);
            setCompanyAddress(companyAddress);
            setCompanyCity(companyCity);
            setCompanyProvince(companyProvince);
            setApprovedEmployer(approvedEmployer);
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
        public string getCompanyName()
        {
            return this.companyName;
        }
        public string getCompanyPosition()
        {
            return this.companyPosition;
        }
        public string getPhoneNumber()
        {
            return this.phoneNumber;
        }
        public string getCompanyAddress()
        {
            return this.companyAddress;
        }
        public string getCompanyCity()
        {
            return this.companyCity;
        }
        public string getCompanyProvince()
        {
            return this.companyProvince;
        }
        public bool getApprovedEmployer()
        {
            return this.approvedEmployer;
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
        public void setCompanyName(string companyName)
        {
            this.companyName = companyName;
        }
        public void setCompanyPosition(string companyPosition)
        {
            this.companyPosition = companyPosition;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void setCompanyAddress(string companyAddress)
        {
            this.companyAddress = companyAddress;
        }
        public void setCompanyCity(string companyCity)
        {
            this.companyCity = companyCity;
        }
        public void setCompanyProvince(string companyProvince)
        {
            this.companyProvince = companyProvince;
        }
        public void setApprovedEmployer(bool approvedEmployer)
        {
            this.approvedEmployer = approvedEmployer;
        }
    }
}
