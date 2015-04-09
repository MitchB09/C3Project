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
    public class InstructorDB
    {
        public static int InsertInstructor(Instructor instructor)
        {
            int createdAccount = 0;

            try
            {
                SqlConnection connection = FinalProjDB.getConnection();
                SqlTransaction transaction;

                connection.Open();

                transaction = connection.BeginTransaction();

                SqlCommand insertAccount = new SqlCommand();
                SqlCommand insertInstructor = new SqlCommand();

                //Setup InsertAccount
                insertAccount.Connection = connection;
                insertAccount.CommandText = "spInsertAccount";
                insertAccount.CommandType = CommandType.StoredProcedure;

                insertAccount.Parameters.AddWithValue("@eMail", instructor.getEMail());
                insertAccount.Parameters.AddWithValue("@password", instructor.getPassword());
                insertAccount.Parameters.AddWithValue("@accountType", "Instructor");

                insertAccount.Parameters["@eMail"].Direction = ParameterDirection.Input;
                insertAccount.Parameters["@password"].Direction = ParameterDirection.Input;
                insertAccount.Parameters["@accountType"].Direction = ParameterDirection.Input;

                //Setup Insert Student
                insertInstructor.Connection = connection;
                insertInstructor.CommandText = "spInsertInstructor";
                insertInstructor.CommandType = CommandType.StoredProcedure;

                insertInstructor.Parameters.AddWithValue("@eMail", instructor.getEMail());
                insertInstructor.Parameters.AddWithValue("@firstName", instructor.getFirstName());
                insertInstructor.Parameters.AddWithValue("@lastName", instructor.getLastName());
                insertInstructor.Parameters.AddWithValue("@program", instructor.getProgram());
                insertInstructor.Parameters.AddWithValue("@campus", instructor.getCampus());
                insertInstructor.Parameters.AddWithValue("@contactInfo", instructor.getContactInfo());

                insertInstructor.Parameters["@eMail"].Direction = ParameterDirection.Input;
                insertInstructor.Parameters["@firstName"].Direction = ParameterDirection.Input;
                insertInstructor.Parameters["@lastName"].Direction = ParameterDirection.Input;
                insertInstructor.Parameters["@program"].Direction = ParameterDirection.Input;
                insertInstructor.Parameters["@campus"].Direction = ParameterDirection.Input;
                insertInstructor.Parameters["@contactInfo"].Direction = ParameterDirection.Input;


                try
                {

                    insertAccount.Transaction = transaction;
                    insertInstructor.Transaction = transaction;


                    createdAccount = insertAccount.ExecuteNonQuery();
                    createdAccount += insertInstructor.ExecuteNonQuery();
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }

                finally
                {
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


            return createdAccount;
        }
    }
}
