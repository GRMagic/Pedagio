//using Pedagio.Cadastro.Domain;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Pedagio.Cadastro.Application.Queries
//{
//    public interface IPassagemQuery
//    {
//        /// <summary>
//        /// Buscar uma passagem pelo seu identificador
//        /// </summary>
//        /// <param name="id">Identificador</param>
//        /// <returns>Dados do passagem ou null quando não encontrada</returns>
//        Task<Passagem> BuscarPorIdAsync(int id);

//        /// <summary>
//        /// Lista as passagens
//        /// </summary>
//        /// <param name="skip">Quantos registros devem ser ignorados</param>
//        /// <param name="take">Quantos registros podem ser carregados</param>
//        /// <returns>Lista com os passagems</returns>
//        Task<IEnumerable<Passagem>> BuscarAsync(int skip = 0, int take = int.MaxValue);

//        /// <summary>
//        /// Busca as passagens de um carro
//        /// </summary>
//        /// <param name="idCarro">Identificador do carro</param>
//        /// <param name="inicio">Data inicial para filtro</param>
//        /// <param name="fim">Data final para filtro</param>
//        /// <returns>Lista de passagens do carro</returns>
//        Task<IEnumerable<Passagem>> BuscarPorCarroAsync(int idCarro, DateTime inicio, DateTime fim);
//    }
//}
