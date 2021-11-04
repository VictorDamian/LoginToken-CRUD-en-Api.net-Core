using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DAO
{
    public abstract class DBConnection
    {
        private readonly string connectionString;
        public DBConnection()
        {
            connectionString = "Server=Dantes;DataBase=VENTAS;Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
