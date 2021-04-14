using Dapper;
using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Data.Dto;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public class ModeloStore : IModeloCommandStore, IModeloQueryStore
    {
        private IDbConnection _dbConnection;

        public ModeloStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<int> InserirAsync(Modelo modelo)
        {
            const string sql = @"insert into modelos (id_modelo, id_marca, nome) values (@Id, @IdMarca, @Nome); select last_insert_id();";

            var dto = new ModeloDto(modelo);
            return _dbConnection.ExecuteScalarAsync<int>(sql, dto);
        }

        public async Task<bool> AtualizarAsync(Modelo modelo)
        {
            const string sql = @"update modelos set nome = @Nome, id_marca = @IdMarca where id_modelo = @Id";

            var dto = new ModeloDto(modelo);
            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, dto);
            return registrosAfetados == 1;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            const string sql = @"delete from modelos where id_modelo = @Id";

            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return registrosAfetados == 1;
        }

        public async Task<Modelo> BuscarPorIdAsync(int id)
        {
            const string sql = @"select id_modelo as Id,
                                        id_marca as IdMarca,
                                        nome as Nome
                                   from modelos
                                  where id_modelo = @Id";

            var dto = await _dbConnection.QueryFirstOrDefaultAsync<ModeloDto>(sql, new { Id = id });
            return dto?.ToModelo();

        }

        public async Task<IEnumerable<Modelo>> BuscarAsync(int skip=0, int take=int.MaxValue)
        {
            const string sql = @"select id_modelo as Id,
                                        id_marca as IdMarca,
                                        nome as Nome
                                   from modelos
                                  limit @Skip, @Take";

            var dtos = await _dbConnection.QueryAsync<ModeloDto>(sql, new { Skip = skip, Take = take });
            return dtos.Select(d => d.ToModelo());
        }

        public async Task<IEnumerable<Modelo>> BuscarPorMarcaAsync(int idMarca, int skip = 0, int take = int.MaxValue)
        {
            const string sql = @"select id_modelo as Id,
                                        id_marca as IdMarca,
                                        nome as Nome
                                   from modelos
                                  where id_marca = @IdMarca
                                  limit @Skip, @Take";

            var dtos = await _dbConnection.QueryAsync<ModeloDto>(sql, new 
            {
                IdMarca = idMarca, 
                Skip = skip, 
                Take = take 
            });
            return dtos.Select(d => d.ToModelo());
        }
    }
}
