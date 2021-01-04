//using Dapper;
//using Pedagio.Cadastro.Data.Dto;
//using Pedagio.Cadastro.Domain;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Pedagio.Cadastro.Data
//{
//    public class PassagemStore : IPassagemStore
//    {
//        private IDbConnection _dbConnection;

//        public PassagemStore(IDbConnection dbConnection)
//        {
//            _dbConnection = dbConnection;
//        }

//        public async Task<int> InserirAsync(Passagem passagem)
//        {
//            const string sql = @"insert into passagens (id_passagem, id_carro, momento, evasao) values (@Id, @IdCarro, @Momento, @Evasao); select last_insert_id();";

//            var dto = new PassagemDto(passagem);
//            return await _dbConnection.ExecuteScalarAsync<int>(sql, dto);
//        }

//        public async Task<bool> AtualizarAsync(Passagem passagem)
//        {
//            const string sql = @"update passagens set id_carro = @IdCarro, momento = @Momento, evasao = @Evasao where id_passagem = @Id";

//            var dto = new PassagemDto(passagem);
//            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, dto);
//            return registrosAfetados == 1;
//        }

//        public async Task<bool> ExcluirAsync(int id)
//        {
//            const string sql = @"delete from passagens where id_passagem = @Id";

//            var registrosAfetados = await _dbConnection.ExecuteAsync(sql, new { Id = id });
//            return registrosAfetados == 1;
//        }

//        public async Task<Passagem> BuscarPorIdAsync(int id)
//        {
//            const string sql = @"select id_passagem as Id,
//                                        id_carro as IdCarro,
//                                        momento as Momento,
//                                        evasao as Evasao
//                                   from passagens
//                                  where id_passagem = @Id";

//            var dto = await _dbConnection.QueryFirstOrDefaultAsync<PassagemDto>(sql, new { Id = id });
//            return dto?.ToPassagem();

//        }

//        public async Task<IEnumerable<Passagem>> BuscarAsync(int skip=0, int take=int.MaxValue)
//        {
//            const string sql = @"select id_passagem as Id,
//                                        id_carro as IdCarro,
//                                        momento as Momento,
//                                        evasao as Evasao
//                                   from passagens
//                                  limit @Skip, @Take";

//            var dtos = await _dbConnection.QueryAsync<PassagemDto>(sql, new { Skip = skip, Take = take });
//            return dtos.Select(d => d.ToPassagem());
//        }

//        public async Task<IEnumerable<Passagem>> BuscarPorCarroAsync(int idCarro, System.DateTime inicio, System.DateTime fim)
//        {
//            const string sql = @"select id_passagem as Id,
//                                        id_carro as IdCarro,
//                                        momento as Momento,
//                                        evasao as Evasao
//                                   from passagens
//                                  where id_carro = @IdCarro
//                                    and momento >= @Inicio
//                                    and momento <  @Fim";

//            var dtos = await _dbConnection.QueryAsync<PassagemDto>(sql, new
//            {
//                IdCarro = idCarro,
//                Inicio = inicio,
//                Fim = fim
//            });
//            return dtos.Select(d => d.ToPassagem());
//        }
//    }
//}
