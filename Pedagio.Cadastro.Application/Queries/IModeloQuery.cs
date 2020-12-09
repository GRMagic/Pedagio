using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public interface IModeloQuery
    {
        /// <summary>
        /// Buscar um modelo pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Dados do modelo ou null quando não encontrado</returns>
        Task<Modelo> BuscarPorIdAsync(int id);

        /// <summary>
        /// Lista os modelos
        /// </summary>
        /// <param name="skip">Quantos registros devem ser ignorados</param>
        /// <param name="take">Quantos registros podem ser carregados</param>
        /// <returns>Lista com os modelos</returns>
        Task<IEnumerable<Modelo>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
