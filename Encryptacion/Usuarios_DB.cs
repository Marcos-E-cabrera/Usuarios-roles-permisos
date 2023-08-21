using Encryptacion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Encryptacion
{
    public class Usuarios_DB
    {
        private string connectionString =
            "Data Source = .; Database = MiSistema; Trusted_Connection = True; " +
            "User = sa; Password = 123456;";

        public List<usuario> Read()
        {
            
            List<usuario> usuarios = new List<usuario>();

            string query = "select id, password from usuario ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    var item = new usuario();
                    item.id = reader.GetInt32(0);
                    item.password = reader.GetString(1);

                    usuarios.Add(item);
                }

                connection.Close();
                reader.Close();
            }

            return usuarios;
        }

        public void Edit( int id, string password)
        {
            string query = "UPDATE usuario set password=@password " +
                            " where id=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }

}
