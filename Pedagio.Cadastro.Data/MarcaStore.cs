using Dapper;
using MySql.Data.MySqlClient;
using Pedagio.Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public class MarcaStore : IMarcaStore
    {
        private IDbConnection _dbConnection;

        public MarcaStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> InserirAsync(Marca marca)
        {
            const string sql = @"insert into marcas (id_marca, nome) values (@Id, @Nome); select last_insert_id();";

            return await _dbConnection.ExecuteScalarAsync<int>(sql, marca);
        }

        public async Task<bool> AtualizarAsync(Marca marca)
        {
            const string sql = @"update marcas set nome = @Nome where id_marca = @Id";

            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, marca);
            return registrosAfetados == 1;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            const string sql = @"delete from marcas where id_marca = @Id";

            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return registrosAfetados == 1;
        }

        public async Task<Marca> BuscarPorIdAsync(int id)
        {
            const string sql = @"select id_marca as Id,
                                        nome as Nome
                                   from marcas
                                  where id_marca = @Id";

            return await _dbConnection.QueryFirstOrDefaultAsync<Marca>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Marca>> BuscarAsync(int skip=0, int take=int.MaxValue)
        {
            const string sql = @"select id_marca as Id,
                                        nome as Nome
                                   from marcas
                                  limit @Skip, @Take";

            return await _dbConnection.QueryAsync<Marca>(sql, new { Skip = skip, Take = take });
        }
    }
}
