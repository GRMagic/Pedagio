using MySql.Data.MySqlClient;
using System.Data;

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
