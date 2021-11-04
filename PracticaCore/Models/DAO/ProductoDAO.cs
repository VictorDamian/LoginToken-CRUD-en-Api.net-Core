using Microsoft.Data.SqlClient;
using PracticaCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DAO
{
    public class ProductoDAO:DBConnection
    {
        public List<SqlParameter> parameter;
        public int ExecuteNonQuery()
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "insert into Employee values(@idNumber, @name, @mail, @birthday)";
                    command.CommandType = System.Data.CommandType.Text;
                    foreach(SqlParameter item in parameter)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameter.Clear();
                    return result;
                }
            }
        }
        public List<Producto> GetProductos()
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select*from Producto";
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    List<Producto> employees = new List<Producto>();
                    while (reader.Read())
                    {
                        employees.Add(new Producto
                        {
                            Id_pro = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            PrecioUnitario = (double)reader.GetDecimal(2),
                            Costo = (double)reader.GetDecimal(3)
                        });
                    }
                    reader.Dispose();
                    return employees;
                }
            }
        }
    }
}
