using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            string SQL = "SELECT eMail, studentID, firstName, lastName, programCode, campus FROM Student";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);                 

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

            string SQL = "SELECT eMail, studentID, firstName, lastName, programCode, phoneNumber, address, city, campus, additionalInfo FROM Student WHERE eMail = @eMail";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            
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
    }
}
