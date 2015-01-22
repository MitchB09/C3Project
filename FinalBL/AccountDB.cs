using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinalDL;

namespace FinalBL
{
    public class AccountDB
    {
        public static Account LogIn(string eMail, string pass)
        {
            Account foundAccount = new Account();

            SqlConnection connection = FinalProjDB.getConnection();

            string SQL = "SELECT eMail, password, AccountType FROM account WHERE eMail = @eMail AND password = @password";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters.AddWithValue("@password", pass);

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                if (reader.Read()) {

                    foundAccount.setEMail(reader.GetString(0));
                    foundAccount.setPassword(reader.GetString(1));
                    foundAccount.setAccountType(reader.GetString(2));

                }

                else
                {
                    foundAccount = null;
                }

                reader.Close();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return foundAccount;
        }

        public static Boolean LogInAttempt(string eMail, string password)
        {
            bool logInSuccess = false;

            SqlConnection connection = FinalProjDB.getConnection();

            string SQL = "SELECT COUNT(eMail) FROM account WHERE eMail = @eMail AND password = @password";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (reader.Read())
                {

                    int foundValue = reader.GetInt32(0);
                    if (foundValue == 1)
                    {
                        logInSuccess = true;
                    }

                }

                
                reader.Close();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return logInSuccess;

        }
    }


}
