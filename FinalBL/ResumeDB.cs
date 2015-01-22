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

            string SQL = "INSERT INTO Resume(eMail, fileName, fileType, dateAdded, docData) VALUES (@eMail, @fileName, @fileType,@dateAdded, @docData)";

            SqlCommand insertCommand = new SqlCommand(SQL, connection);

            insertCommand.Parameters.AddWithValue("@eMail", eMail);
            insertCommand.Parameters.AddWithValue("@fileName", fileName);
            insertCommand.Parameters.AddWithValue("@fileType", fileType);
            insertCommand.Parameters.AddWithValue("@dateAdded", dateAdded);
            insertCommand.Parameters.AddWithValue("@docData", documentBinary);

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

            string SQL = "UPDATE Resume SET fileName = @fileName, fileType =  @fileType, dateAdded = @dateAdded, docData = @docData WHERE eMail = @eMail";

            SqlCommand updateCommand = new SqlCommand(SQL, connection);

            updateCommand.Parameters.AddWithValue("@eMail", eMail);
            updateCommand.Parameters.AddWithValue("@fileName", fileName);
            updateCommand.Parameters.AddWithValue("@fileType", fileType);
            updateCommand.Parameters.AddWithValue("@dateAdded", dateAdded);
            updateCommand.Parameters.AddWithValue("@docData", documentBinary);

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

            string SQL = "SELECT fileName, fileType, dateAdded, docData FROM Resume WHERE eMail = @eMail";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);

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

            string SQL = "SELECT fileName, fileType FROM Resume WHERE eMail = @eMail";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);

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

            string SQL = "SELECT Count(fileName) FROM Resume WHERE eMail = @eMail";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);

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
