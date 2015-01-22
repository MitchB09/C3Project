using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FinalDL
{
    public class FinalProjDB
    {
        public static SqlConnection getConnection()
        {
            String connectionString = "Data Source=localhost;Initial Catalog=FinalProj;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
