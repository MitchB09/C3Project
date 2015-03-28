using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spLogIn";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@email"].Direction = ParameterDirection.Input;
            
            selectCommand.Parameters.AddWithValue("@password", pass);
            selectCommand.Parameters["@password"].Direction = ParameterDirection.Input;

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

        public static bool LogInAttempt(string eMail, string password)
        {
            bool logInSuccess = false;

            SqlConnection connection = FinalProjDB.getConnection();            

            SqlCommand selectCommand = new SqlCommand();
            
            selectCommand.Connection = connection;
            selectCommand.CommandText = "spLogInAttempt";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;

            selectCommand.Parameters.AddWithValue("@password", password);
            selectCommand.Parameters["@password"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleResult);

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

        public static int CreateAccount(string eMail, string password, string accountType)
        {
            int created = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand insertCommand = new SqlCommand();

            insertCommand.Connection = connection;
            insertCommand.CommandText = "spInsertAccount";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@eMail", eMail);
            insertCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters["@password"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@accountType", accountType);
            insertCommand.Parameters["@accountType"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                created = insertCommand.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return created;
        }

        public static bool FindAccountByEmail(string eMail)
        {
            bool found = false;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spFindAccountByEmail";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;
            
            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleResult);

                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                    {
                        found = true;
                    }     
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static int UpdatePassword(string eMail, string password)
        {
            int updatedRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spUpdatePasswordByEmail";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@eMail", eMail);
            updateCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@password", password);
            updateCommand.Parameters["@password"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                updatedRecords = updateCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return updatedRecords;
        }
    }


}
