using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBL
{
    public class Account
    {

        private string eMail;
        private string password;
        private string accountType;

        //Constuctors
        public Account()
        {

        }

        public Account(string eMail, string password, string accountType)
        {
            setEMail(eMail);
            setPassword(password);
            setAccountType(accountType);
        }

        //Getters
        public string getEMail()
        {
            return this.eMail;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getAccountType()
        {
            return this.accountType;
        }

        //Setters
        public void setEMail(string eMail)
        {
            this.eMail = eMail;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public void setAccountType(string accountType)
        {
            this.accountType = accountType;
        }
    }
}
