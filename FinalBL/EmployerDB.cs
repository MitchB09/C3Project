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
    public class EmployerDB
    {
        public static Employer EmployerByEMail(string eMail)
        {
            Employer employer = new Employer();
            
            SqlConnection connection = FinalProjDB.getConnection();
            
            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spEmployerByEmail";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@eMail", eMail);
            selectCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    //Assigns vales to student object
                    //Only fiels that are nullable in database are checked for null values

                    employer.setEMail(eMail);
                    employer.setFirstName(reader.GetString(0));
                    employer.setLastName(reader.GetString(1));
                    employer.setCompanyName(reader.GetString(2));

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(3))
                    {
                        employer.setCompanyPosition(reader.GetString(3));
                    }
                    else
                    {
                        employer.setCompanyPosition(String.Empty);
                    }

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(4))
                    {
                        employer.setPhoneNumber(reader.GetString(4));
                    }
                    else
                    {
                        employer.setPhoneNumber(String.Empty);
                    }

                    employer.setCompanyAddress(reader.GetString(5));
                    employer.setCompanyCity(reader.GetString(6));
                    employer.setCompanyProvince(reader.GetString(7));


                }

                else
                {
                    employer = null;
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

            return employer;
        }

        public static bool ApprovedEmployer(string eMail)
        {
            bool approvedEmployer = false;

            SqlConnection connection = FinalProjDB.getConnection();

            string SQL = "SELECT approvedEmployer FROM Employer WHERE eMail = @eMail";

            SqlCommand selectCommand = new SqlCommand(SQL, connection);

            selectCommand.Parameters.AddWithValue("@eMail", eMail);

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        approvedEmployer = (bool)reader["approvedEmployer"];
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

            return approvedEmployer;
        }

        public static List<Employer> UnvettedEmployers(int pageNum)
        {
            List<Employer> UnvettedEmployers = new List<Employer>();

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spUnapprovedEmployersRange";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.AddWithValue("@pageNum", pageNum);
            selectCommand.Parameters["@pageNum"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Employer employer = new Employer();
                    employer.setEMail(reader.GetString(0));
                    employer.setFirstName(reader.GetString(1));
                    employer.setLastName(reader.GetString(2));
                    employer.setCompanyName(reader.GetString(3));

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(4))
                    {
                        employer.setCompanyPosition(reader.GetString(4));
                    }
                    else
                    {
                        employer.setCompanyPosition(String.Empty);
                    }

                    //Checks if value is null if so assigns empty value
                    if (!reader.IsDBNull(5))
                    {
                        employer.setPhoneNumber(reader.GetString(5));
                    }
                    else
                    {
                        employer.setPhoneNumber(String.Empty);
                    }

                    employer.setCompanyAddress(reader.GetString(6));
                    employer.setCompanyCity(reader.GetString(7));
                    employer.setCompanyProvince(reader.GetString(8));

                    UnvettedEmployers.Add(employer);
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

            return UnvettedEmployers;
        }

        public static int UnvettedEmployersCount()
        {
            int totalRecords = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand selectCommand = new SqlCommand();

            selectCommand.Connection = connection;
            selectCommand.CommandText = "spUnvettedEmployersCount";
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
        
        public static int ApproveEmployer(string empEMail){

            int updated = 0;

            SqlConnection connection = FinalProjDB.getConnection();

            SqlCommand updateCommand = new SqlCommand();

            updateCommand.Connection = connection;
            updateCommand.CommandText = "spApproveEmployer";
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.AddWithValue("@eMail", empEMail);
            updateCommand.Parameters["@eMail"].Direction = ParameterDirection.Input;

            try
            {
                connection.Open();

                updated = updateCommand.ExecuteNonQuery();
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return updated;
        }
    }
}
