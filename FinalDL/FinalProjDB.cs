﻿using System;
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
            String connectionString = "Data Source=localhost;Initial Catalog=C3MBilensky_test;Persist Security Info=True;User ID=mbilensky;Password=Pass5000067!";
            return new SqlConnection(connectionString);
        }
    }
}
