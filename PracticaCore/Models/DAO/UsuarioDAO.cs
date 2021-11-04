using Microsoft.Data.SqlClient;
using PracticaCore.Models.DTO;
using PracticaCore.Models.ObjectValues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DAO
{
    public class UsuarioDAO:DBConnection
    {
        public bool GetUsuarios(string usr, string pass)
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select * from usuarios where username = @user and CONVERT(NVARCHAR(MAX),DECRYPTBYPASSPHRASE('PASSWORD',PASSWORD)) = @pass";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@user", usr);
                    command.Parameters.AddWithValue("@pass", pass);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Usuarios> generic = new List<Usuarios>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.idusr = reader.GetInt64(0);
                            UserCache.username = reader.GetString(1);
                            UserCache.email = reader.GetString(2);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
