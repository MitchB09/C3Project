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
    public class StudentDB
    {
        //Returns list of students used to populate the browsing details needed for students.aspx 
        public static List<Student> getStudentDisplayList()
        {
            List<Student> studentList = new List<Student>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetStudentDisplayList";
            selectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read()) {
                    Student student = new Student();

                    student.setEMail(reader.GetString(0));
                    student.setStudentID(reader.GetString(1));
                    student.setFirstName(reader.GetString(2));
                    student.setLastName(reader.GetString(3));
                    student.setProgram(reader.GetString(4));
                    student.setCampus(reader.GetString(5));
                    studentList.Add(student);
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

            return studentList;
        }

        //Returns single student based upon eMail
        public static Student StudentByEMail(string eMail)
        {
            Student student = new Student();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetStudentByEmail";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@email", eMail);
            selectCommand.Parameters["@email"].Direction = ParameterDirection.Input;
            
            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    //Assigns vales to student object
                    //Only fiels that are nullable in database are checked for null values

                    student.setEMail(reader.GetString(0));
                    student.setStudentID(reader.GetString(1));
                    student.setFirstName(reader.GetString(2));
                    student.setLastName(reader.GetString(3));
                    student.setProgram(reader.GetString(4));

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(5))
                    {
                        student.setPhoneNumber(reader.GetString(5));
                    }
                    else
                    {
                        student.setPhoneNumber(String.Empty);
                    }
                    
                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(6))
                    {
                        student.setAddress(reader.GetString(6));
                    }
                    else
                    {
                        student.setAddress(String.Empty);
                    }

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(7))
                    {
                        student.setCity(reader.GetString(7));
                    }
                    else
                    {
                        student.setCity(String.Empty);
                    }
                    
                    student.setCampus(reader.GetString(8));
                    
                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(9))
                    {
                        student.setAdditionalInfo(reader.GetString(9));
                    }
                    else
                    {
                        student.setAdditionalInfo(String.Empty);
                    }
                    

                }

                else
                {
                    student = null;
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

            return student;
        }
    
        public static List<Student> getStudentRange(int pageNum)
        {
            List<Student> studentList = new List<Student>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetStudentByRange";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@pageNum", pageNum);
            selectCommand.Parameters["@pageNum"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();

                    student.setEMail(reader.GetString(0));
                    student.setStudentID(reader.GetString(1));
                    student.setFirstName(reader.GetString(2));
                    student.setLastName(reader.GetString(3));
                    student.setProgram(reader.GetString(4));
                    
                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(5))
                    {
                        student.setPhoneNumber(reader.GetString(5));
                    }
                    else
                    {
                        student.setPhoneNumber(String.Empty);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        student.setAddress(reader.GetString(6));
                    }
                    else
                    {
                        student.setAddress(String.Empty);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        student.setCity(reader.GetString(7));
                    }
                    else
                    {
                        student.setCity(String.Empty);
                    }

                    student.setCampus(reader.GetString(8));

                    if (!reader.IsDBNull(9))
                    {
                        student.setAdditionalInfo(reader.GetString(9));
                    }
                    else
                    {
                        student.setAdditionalInfo(String.Empty);
                    }
                    
                    //Adds Student to list
                    studentList.Add(student);
                    
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

            return studentList;
        }

        public static int InsertStudent(Student student/*string email, string password, string studentID, string firstName, string lastName,
            string programCode, string phoneNumber, string address, string city, string campus, string additionalInfo */)
        {
            int createdAccount = 0;                  

            try
            {
                SqlConnection connection = FinalProjDB.getConnection();
                SqlTransaction transaction;

                connection.Open();

                transaction = connection.BeginTransaction();

                SqlCommand insertAccount = new SqlCommand();
                SqlCommand insertStudent = new SqlCommand();

                //Setup InsertAccount
                insertAccount.Connection = connection;
                insertAccount.CommandText = "spInsertAccount";
                insertAccount.CommandType = CommandType.StoredProcedure;

                insertAccount.Parameters.AddWithValue("@eMail", student.getEMail());
                insertAccount.Parameters.AddWithValue("@password", student.getPassword());
                insertAccount.Parameters.AddWithValue("@accountType", "Student");

                insertAccount.Parameters["@eMail"].Direction = ParameterDirection.Input;
                insertAccount.Parameters["@password"].Direction = ParameterDirection.Input;
                insertAccount.Parameters["@accountType"].Direction = ParameterDirection.Input;

                //Setup Insert Student
                insertStudent.Connection = connection;
                insertStudent.CommandText = "spInsertStudent";
                insertStudent.CommandType = CommandType.StoredProcedure;

                insertStudent.Parameters.AddWithValue("@eMail", student.getEMail());
                insertStudent.Parameters.AddWithValue("@studentID", student.getStudentID());
                insertStudent.Parameters.AddWithValue("@firstName", student.getFirstName());
                insertStudent.Parameters.AddWithValue("@lastName", student.getLastName());
                insertStudent.Parameters.AddWithValue("@programCode", student.getProgram());                
                insertStudent.Parameters.AddWithValue("@phoneNumber", student.getPhoneNumber());
                insertStudent.Parameters.AddWithValue("@address", student.getAddress());
                insertStudent.Parameters.AddWithValue("@city", student.getCity());
                insertStudent.Parameters.AddWithValue("@campus", student.getCampus());
                insertStudent.Parameters.AddWithValue("@additionalInfo", student.getAdditionalInfo());

                insertStudent.Parameters["@eMail"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@studentID"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@firstName"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@lastName"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@programCode"].Direction = ParameterDirection.Input;                
                insertStudent.Parameters["@phoneNumber"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@address"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@city"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@campus"].Direction = ParameterDirection.Input;
                insertStudent.Parameters["@additionalInfo"].Direction = ParameterDirection.Input;

                //


                try
                {

                    insertAccount.Transaction = transaction;
                    insertStudent.Transaction = transaction;


                    createdAccount = insertAccount.ExecuteNonQuery();
                    createdAccount += insertStudent.ExecuteNonQuery();
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

        public static int StudentCount()
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spGetStudentCount";
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
        
        public static int SelfUpdateStudent(string email, string phoneNumber, string address, string city, string additionalInfo)
        {
            int createdAccount = 0;
            
            SqlConnection connection = FinalProjDB.getConnection();                
                
            SqlCommand updateStudent = new SqlCommand();                

            //Setup Update Student
            updateStudent.Connection = connection;
            updateStudent.CommandText = "spSelfUpdateStudent";
            updateStudent.CommandType = CommandType.StoredProcedure;

            updateStudent.Parameters.AddWithValue("@eMail", email);                
            updateStudent.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            updateStudent.Parameters.AddWithValue("@address", address);
            updateStudent.Parameters.AddWithValue("@city", city);                
            updateStudent.Parameters.AddWithValue("@additionalInfo", additionalInfo);

            updateStudent.Parameters["@eMail"].Direction = ParameterDirection.Input;                
            updateStudent.Parameters["@phoneNumber"].Direction = ParameterDirection.Input;
            updateStudent.Parameters["@address"].Direction = ParameterDirection.Input;
            updateStudent.Parameters["@city"].Direction = ParameterDirection.Input;                
            updateStudent.Parameters["@additionalInfo"].Direction = ParameterDirection.Input;

            //


            try
            {

                connection.Open();                
                createdAccount += updateStudent.ExecuteNonQuery();                
            }

            catch (Exception ex)
            {                
                throw ex;
            }

            finally
            {
                connection.Close();
            }     


            return createdAccount;
        }
    }
}
