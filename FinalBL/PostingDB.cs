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
        public static int CreatePosting(string eMail, string company, string contact, string jobTitle, string additionalInfo)
        {
            SqlConnection connection = FinalProjDB.getConnection();            

            SqlCommand insertCommand = new SqlCommand();

            insertCommand.Connection = connection;
            insertCommand.CommandText = "spInsertPosting";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@empEmail", eMail);
            insertCommand.Parameters.AddWithValue("@company", company);
            insertCommand.Parameters.AddWithValue("@contact", contact);
            insertCommand.Parameters.AddWithValue("@dateAdded", System.DateTime.Now);
            insertCommand.Parameters.AddWithValue("@jobTitle", jobTitle);
            insertCommand.Parameters.AddWithValue("@addInfo", additionalInfo);

            insertCommand.Parameters["@empEmail"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@company"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@contact"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@jobTitle"].Direction = ParameterDirection.Input;
            insertCommand.Parameters["@addInfo"].Direction = ParameterDirection.Input;
                        
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
                    posting.setCompanyName(reader.GetString(5));
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
                    posting.setCompany(reader.GetString(1));
                    posting.setContact(reader.GetString(2));
                    posting.setDateAdded(reader.GetDateTime(3));
                    posting.setJobTitle(reader.GetString(4));                   
                    posting.setAdditionalInfo(reader.GetString(5));                    
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
                    posting.setCompany(reader.GetString(1));
                    posting.setContact(reader.GetString(2));
                    posting.setJobTitle(reader.GetString(3));
                    posting.setEmpEmail(reader.GetString(4));
                    posting.setDateAdded(reader.GetDateTime(5));
                    posting.setAdditionalInfo(reader.GetString(6));
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
    
        public static int RemovePosting(Posting post, string email, string reason)
        {
            int insertedRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();
            SqlCommand insertCommand = new SqlCommand();

            insertCommand.Connection = connection;
            insertCommand.CommandText = "spRemovePosting";
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.AddWithValue("@postID", post.getPostID());
            insertCommand.Parameters["@postID"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@empEmail", post.getEmpEmail());
            insertCommand.Parameters["@empEmail"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@dateAdded", post.getDateAdded());
            insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@jobTitle", post.getJobTitle());
            insertCommand.Parameters["@jobTitle"].Direction = ParameterDirection.Input;            

            insertCommand.Parameters.AddWithValue("@additionalInfo", post.getAdditionalInfo());
            insertCommand.Parameters["@additionalInfo"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@removedBy", email);
            insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@dateRemoved", System.DateTime.Now.Date);
            insertCommand.Parameters["@dateRemoved"].Direction = ParameterDirection.Input;

            insertCommand.Parameters.AddWithValue("@reason", reason);
            insertCommand.Parameters["@reason"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();
                insertedRecords = insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return insertedRecords;
        }
    
        public static bool PostingExists(int postID)
        {
            bool foundRecord = false;

            SqlConnection connection = FinalProjDB.getConnection();
            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spFindPostingById";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@postID", postID);
            selectCommand.Parameters["@postID"].Direction = ParameterDirection.Input;

            

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleResult);

                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                    {
                        foundRecord = true;
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

            return foundRecord;
        }
    }

}
