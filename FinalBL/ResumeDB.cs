using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinalDL;

namespace FinalBL
{
    public class ResumeDB
    {
        public static int UploadResume(string eMail, string fileName, string fileType, DateTime dateAdded, byte[] documentBinary, int fileSize)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand insertCommand = new SqlCommand();

            insertCommand.Connection = connection;
            insertCommand.CommandText = "spInsertResume";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@email", eMail);
            insertCommand.Parameters["@email"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@fileName", fileName);
            insertCommand.Parameters["@fileName"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@fileType", fileType);
            insertCommand.Parameters["@fileType"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@dateAdded", dateAdded);
            insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@docData", documentBinary);
            insertCommand.Parameters["@docData"].Direction = ParameterDirection.Input;

            int result = 0;

            try
            {
                connection.Open();
                result = insertCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public static int UpdateResume(string eMail, string fileName, string fileType, DateTime dateAdded, byte[] documentBinary, int fileSize)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spUpdateResume";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@email", eMail);
            updateCommand.Parameters["@email"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@fileName", fileName);
            updateCommand.Parameters["@fileName"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@fileType", fileType);
            updateCommand.Parameters["@fileType"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@dateAdded", dateAdded);
            updateCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@docData", documentBinary);
            updateCommand.Parameters["@docData"].Direction = ParameterDirection.Input;

            int result = 0;

            try
            {
                connection.Open();
                result = updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
        
        public static Resume GetResume(string eMail)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetResume";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@email", eMail);
            selectCommand.Parameters["@email"].Direction = ParameterDirection.Input;

            Resume resume = new Resume();                   

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                

                if (reader.Read())
                {
                    resume.setFileName(reader.GetString(0));
                    resume.setFileType(reader.GetString(1));
                    resume.setDateAdded(reader.GetDateTime(2));
                    resume.setDocData((byte[])reader["DocData"]);                                      
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return resume;

        }

        public static Resume GetResumeName(string eMail)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetResumeName";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@email", eMail);
            selectCommand.Parameters["@email"].Direction = ParameterDirection.Input;

            Resume resume = new Resume();

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();



                if (reader.Read())
                {
                    resume.setFileName(reader.GetString(0));
                    resume.setFileType(reader.GetString(1));                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return resume;

        }

        public static bool FindResume(string eMail)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spFindResume";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@email", eMail);
            selectCommand.Parameters["@email"].Direction = ParameterDirection.Input;

            bool found = false;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                    {
                        found = true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return found;
        }
    }
}
