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
    public class PostingDB
    {
        public static int CreatePosting(string eMail, string jobTitle, string additionalInfo)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            string SQL = "INSERT INTO Posting(empEmail, dateAdded, jobTitle, additionalInfo) VALUES (@eMail, @dateAdded, @jobTitle, @additionalInfo)";

            SqlCommand insertCommand = new SqlCommand(SQL, connection);

            insertCommand.Parameters.AddWithValue("@eMail", eMail);
            insertCommand.Parameters.AddWithValue("@dateAdded", System.DateTime.Now);
            insertCommand.Parameters.AddWithValue("@jobTitle", jobTitle);
            insertCommand.Parameters.AddWithValue("@additionalInfo", additionalInfo);
            
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

        public static List<Posting> GetPostings(int pageNum)
        {
            List<Posting> PostingList = new List<Posting>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spSelectPostingRange";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@pageNum", pageNum);
            selectCommand.Parameters["@pageNum"].Direction = ParameterDirection.Input;                      

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Posting posting = new Posting();
                    posting.setPostID(reader.GetInt32(0));
                    posting.setJobTitle(reader.GetString(1));
                    posting.setEmpEmail(reader.GetString(2));
                    posting.setDateAdded(reader.GetDateTime(3));
                    posting.setAdditionalInfo(reader.GetString(4));
                    PostingList.Add(posting);
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

            return PostingList;
        }

        public static Posting GetPostingByPostID(int postID)
        {
            Posting posting = new Posting();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPosting";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@postID", postID);
            selectCommand.Parameters["@postID"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    posting.setPostID(postID);
                    posting.setEmpEmail(reader.GetString(0));
                    posting.setDateAdded(reader.GetDateTime(1));
                    posting.setJobTitle(reader.GetString(2));                   
                    posting.setAdditionalInfo(reader.GetString(3));                    
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

            return posting;
        }

        public static int GetPostingCount()
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPostingCount";
            selectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleResult);

                if (reader.Read())
                {
                    totalRecords = reader.GetInt32(0);
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

            return totalRecords;
        }

        public static List<Posting> GetPostingByEmail(int pageNum, string eMail)
        {
            
            List<Posting> PostingList = new List<Posting>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spPostingByEmailRange";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@pageNum", pageNum);
            selectCommand.Parameters["@pageNum"].Direction = ParameterDirection.Input;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;  

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Posting posting = new Posting();
                    posting.setPostID(reader.GetInt32(0));
                    posting.setJobTitle(reader.GetString(1));
                    posting.setEmpEmail(reader.GetString(2));
                    posting.setDateAdded(reader.GetDateTime(3));
                    posting.setAdditionalInfo(reader.GetString(4));
                    PostingList.Add(posting);
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

            return PostingList;
        }

        public static int GetPostingCountByEmail(string eMail)
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPostingByEmailCount";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;  

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleResult);

                if (reader.Read())
                {
                    totalRecords = reader.GetInt32(0);
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

            return totalRecords;
        }

        public static int UpdatePosting(int postID, string jobTitle, string additionalInfo)
        {
            int updatedRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();
            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spUpdatePosting";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@postID", postID);
            updateCommand.Parameters["@postID"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@jobTitle", jobTitle);
            updateCommand.Parameters["@jobTitle"].Direction = ParameterDirection.Input;

            updateCommand.Parameters.AddWithValue("@additionalInfo", additionalInfo);
            updateCommand.Parameters["@additionalInfo"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();
                updatedRecords = updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
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
