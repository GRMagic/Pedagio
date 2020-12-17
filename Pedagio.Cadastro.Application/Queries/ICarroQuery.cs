using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public interface ICarroQuery
    {
        /// <summary>
        /// Buscar um carro pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Dados do carro ou null quando não encontrado</returns>
        Task<Carro> BuscarPorIdAsync(int id);

        /// <summary>
        /// Buscar um carro pela placa
        /// </summary>
        /// <param name="placa">Placa do carro</param>
        /// <returns>Dados do carro ou null quando não encontrado</returns>
        Task<Carro> BuscarPorPlacaAsync(string placa);

        /// <summary>
        /// Lista os carros
        /// </summary>
        /// <param name="skip">Quantos registros devem ser ignorados</param>
        /// <param name="take">Quantos registros podem ser carregados</param>
        /// <returns>Lista com os carros</returns>
        Task<IEnumerable<Carro>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
