using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public static class ConexaoBanco
    {
        public static IDbConnection Conectar(string connectionString)
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
