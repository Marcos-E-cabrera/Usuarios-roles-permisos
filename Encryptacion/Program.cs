using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptacion
{
    internal class Program
    {

        static void Main(string[] args)
        {
            using (Models.MiSistemaEntities db = new Models.MiSistemaEntities())
            {
                try
                {
                    Usuarios_DB usuarios_DB = new Usuarios_DB();

                    foreach (var item in usuarios_DB.Read())
                    {
                        usuarios_DB.Edit(item.id, Encrypt.GetSHA2S6(item.password));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


        }
    }
}
