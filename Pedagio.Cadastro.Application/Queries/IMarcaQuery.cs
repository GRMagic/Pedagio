using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public interface IMarcaQuery
    {
        /// <summary>
        /// Buscar uma marca pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Dados da marca ou null quando não encontrada</returns>
        Task<Marca> BuscarPorIdAsync(int id);

        /// <summary>
        /// Lista as marcas
        /// </summary>
        /// <param name="skip">Quantos registros devem ser ignorados</param>
        /// <param name="take">Quantos registros podem ser carregados</param>
        /// <returns>Lista com as marcas</returns>
        Task<IEnumerable<Marca>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
