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
    public class PublicFileDB
    {
        public static int UploadFile(string fileName, string fileType, DateTime dateAdded, byte[] documentBinary)
        {
            SqlConnection connection = FinalProjDB.getConnection();                  

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "spInsertPublicFile";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@fileName", fileName);
            insertCommand.Parameters.AddWithValue("@fileType", fileType);
            insertCommand.Parameters.AddWithValue("@dateAdded", dateAdded);
            insertCommand.Parameters.AddWithValue("@fileData", documentBinary);

            insertCommand.Parameters["@fileName"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@fileType"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@fileData"].Direction = ParameterDirection.Input;

            int result = 0;

            try
            {
                connection.Open();
                result = insertCommand.ExecuteNonQuery();
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

        public static List<PublicFile> GetPublicFiles()
        {
            List<PublicFile> fileList = new List<PublicFile>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPublicFiles";
            selectCommand.CommandType = CommandType.StoredProcedure;
             

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    PublicFile file = new PublicFile();

                    file.setFileId(reader.GetInt32(0));
                    file.setFileName(reader.GetString(1));
                    file.setFileType(reader.GetString(2));
                    file.setDateAdded(reader.GetDateTime(3));
                    file.setFileData((byte[])reader[4]);

                    fileList.Add(file);
                                        
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

            return fileList;
        }
    
        public static PublicFile GetPublicFileById(int fileId)
        {
            PublicFile file = new PublicFile();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPublicFileById";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@fileId", fileId);
            selectCommand.Parameters["@fileId"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    file.setFileId(fileId);
                    file.setFileName(reader.GetString(0));
                    file.setFileType(reader.GetString(1));
                    file.setDateAdded(reader.GetDateTime(2));
                    file.setFileData((byte[])reader[3]);
                    
                }

            }

            catch (Exception ex)
            {
                file = null;
                throw ex;                
            }

            finally
            {
                connection.Close();
            }

            return file;
        }

        public static int RemoveFile(int fileID)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "spRemovePublicFile";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@fileId", fileID);

            insertCommand.Parameters["@fileId"].Direction = ParameterDirection.Input;
            

            int result = 0;

            try
            {
                connection.Open();
                result = insertCommand.ExecuteNonQuery();
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
    }
}
