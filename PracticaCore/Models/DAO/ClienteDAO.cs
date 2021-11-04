using Microsoft.Data.SqlClient;
using PracticaCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DAO
{
    public class ClienteDAO:DBConnection
    {
        public List<SqlParameter> parameters;
        public int ExecuteNonQuery()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "insert into cliente values(@Nombre)";
                    command.CommandType = CommandType.Text;
                    foreach(SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }
        public int ExecuteUpdate()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "update cliente set Nombre=@Nombre where Id_cli=@Id_cli";
                    command.CommandType = CommandType.Text;
                    foreach(SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }
        public int ExecuteDelete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "delete from cliente where id_cli=@condicion";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@condicion", id);
                    foreach (SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }
        public List<Cliente> GetClientes()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select*from cliente order by id_cli desc";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    List<Cliente> clientes = new List<Cliente>();
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id_cli = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    return clientes;
                }
            }
        }
        public List<Cliente> FIndById(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select * from Cliente where id_cli like @condicion";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@condicion", id);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Cliente> genericList = new List<Cliente>();
                    while (reader.Read())
                    {
                        genericList.Add(new Cliente
                        {
                            Id_cli = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    return genericList;
                }
            }
        }
    }
}
