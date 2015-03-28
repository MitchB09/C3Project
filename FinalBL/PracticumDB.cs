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
    public class PracticumDB
    {
        
        public static int insertPracticum(Practicum practicum)
        {
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand insertCommand = new SqlCommand();

            if (practicum.getPostID() != 0)
            {
                insertCommand.Connection = connection;
                insertCommand.CommandText = "spInsertPracticumByPostId";
                insertCommand.CommandType = CommandType.StoredProcedure;

                insertCommand.Parameters.AddWithValue("@stuEmail", practicum.getStuEmail());
                insertCommand.Parameters.AddWithValue("@postID", practicum.getPostID());
                insertCommand.Parameters.AddWithValue("@dateAdded", practicum.getDateAdded());                

                insertCommand.Parameters["@stuEmail"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@postID"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;
            }
            else 
            {
                insertCommand.Connection = connection;
                insertCommand.CommandText = "spInsertPracticum";
                insertCommand.CommandType = CommandType.StoredProcedure;

                insertCommand.Parameters.AddWithValue("@stuEmail", practicum.getStuEmail());
                insertCommand.Parameters.AddWithValue("@empEmail", practicum.getEmpEmail());
                insertCommand.Parameters.AddWithValue("@dateAdded", practicum.getDateAdded());
                insertCommand.Parameters.AddWithValue("@company", practicum.getCompany());
                insertCommand.Parameters.AddWithValue("@contact", practicum.getContact());
                insertCommand.Parameters.AddWithValue("@AdditionalDetails", practicum.getAddDetails());

                insertCommand.Parameters["@stuEmail"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@empEmail"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@company"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@contact"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@dateAdded"].Direction = ParameterDirection.Input;
                insertCommand.Parameters["@AdditionalDetails"].Direction = ParameterDirection.Input;
            }
            

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
    
        public static List<Practicum> GetUnapprovedPracticums(int pageNum)
        {
            List<Practicum> practicumList = new List<Practicum>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetUnapprovedPracticumsByRange";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@pageNum", pageNum);
            selectCommand.Parameters["@pageNum"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Practicum practicum = new Practicum();
                    practicum.setPracticumID(reader.GetInt32(0));
                    practicum.setStuEmail(reader.GetString(1));
                    
                    string empEmail = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);
                    practicum.setEmpEmail(empEmail);      
     
                    practicum.setDateAdded(reader.GetDateTime(3));

                    string company = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
                    practicum.setCompany(company);

                    string contact = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
                    practicum.setContact(contact);

                    string addDetails = reader.IsDBNull(6) ? String.Empty : reader.GetString(6);
                    practicum.setAddDetails(addDetails);

                    int postID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                    practicum.setPostID(postID);

                    practicumList.Add(practicum);
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

            return practicumList;
        }

        public static int GetPracticumCount()
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPracticumCount";
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

        public static int GetUnapprovedPracticumCount()
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetUnapprovedPracticumCount";
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

        public static Practicum GetPracticumByID(int practicumID)
        {
            Practicum practicum = new Practicum();
            
            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetPracticumById";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@PracticumID", practicumID);
            selectCommand.Parameters["@PracticumID"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    practicum.setPracticumID(practicumID);
                    practicum.setStuEmail(reader.GetString(0));

                    string empEmail = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
                    practicum.setEmpEmail(empEmail);

                    practicum.setDateAdded(reader.GetDateTime(2));

                    string company = reader.IsDBNull(3) ? String.Empty : reader.GetString(3);
                    practicum.setCompany(company);

                    string contact = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
                    practicum.setContact(contact);

                    string addDetails = reader.IsDBNull(5) ? String.Empty : reader.GetString(5);
                    practicum.setAddDetails(addDetails);

                    int postID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    practicum.setPostID(postID);                   
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

            return practicum;
        }
    

        public static bool ApprovePracticum(Practicum practicum)
        {
            bool success = false;

            SqlConnection connection = FinalProjDB.getConnection();            

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spApprovePracticum";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@practicumId", practicum.getPracticumID());
            updateCommand.Parameters["@practicumId"].Direction = ParameterDirection.Input;            

            try
            {
                connection.Open();

                if (updateCommand.ExecuteNonQuery() > 0)
                {
                    if (practicum.getPostID() != 0)
                    {
                        PostingDB.FillPosting(practicum.getPostID());
                    }
                    success = true;                    
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
            
            return success;
        }

        public static bool RejectPracticum(Practicum practicum)
        {
            bool success = false;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spRejectPracticum";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@practicumId", practicum.getPracticumID());
            updateCommand.Parameters["@practicumId"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                if (updateCommand.ExecuteNonQuery() > 0)
                {
                    if (practicum.getPostID() != 0)
                    {
                        PostingDB.FillPosting(practicum.getPostID());
                    }
                    success = true;
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

            return success;
        }
    }
}
