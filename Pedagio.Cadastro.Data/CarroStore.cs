using Dapper;
using Pedagio.Cadastro.Data.Dto;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public class CarroStore : ICarroStore
    {
        private IDbConnection _dbConnection;

        public CarroStore(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> InserirAsync(Carro carro)
        {
            const string sql = @"insert into carros (id_carro, id_modelo, placa, ano) values (@Id, @IdModelo, @Placa, @Ano); select last_insert_id();";

            var dto = new CarroDto(carro);
            return await _dbConnection.ExecuteScalarAsync<int>(sql, dto);
        }

        public async Task<bool> AtualizarAsync(Carro carro)
        {
            const string sql = @"update carros set placa = @Placa, id_modelo = @IdModelo, ano = @Ano where id_carro = @Id";

            var dto = new CarroDto(carro);
            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, dto);
            return registrosAfetados == 1;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            const string sql = @"delete from carros where id_carro = @Id";

            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return registrosAfetados == 1;
        }

        public async Task<Carro> BuscarPorIdAsync(int id)
        {
            const string sql = @"select id_carro as Id,
                                        id_modelo as IdModelo,
                                        placa as Placa,
                                        ano as Ano
                                   from carros
                                  where id_carro = @Id";

            var dto = await _dbConnection.QueryFirstOrDefaultAsync<CarroDto>(sql, new { Id = id });
            return dto?.ToCarro();
        }

        public async Task<IEnumerable<Carro>> BuscarAsync(int skip=0, int take=int.MaxValue)
        {
            const string sql = @"select id_carro as Id,
                                        id_modelo as IdModelo,
                                        placa as Placa,
                                        ano as Ano
                                   from carros
                                  limit @Skip, @Take";

            var dtos = await _dbConnection.QueryAsync<CarroDto>(sql, new { Skip = skip, Take = take });
            return dtos.Select(d => d.ToCarro());
        }

        public async Task<Carro> BuscarPorPlacaAsync(string placa)
        {
            const string sql = @"select id_carro as Id,
                                        id_modelo as IdModelo,
                                        placa as Placa,
                                        ano as Ano
                                   from carros
                                  where placa = @Placa";

            var dto = await _dbConnection.QueryFirstOrDefaultAsync<CarroDto>(sql, new { Placa = placa });
            return dto?.ToCarro();
        }
    }
}
