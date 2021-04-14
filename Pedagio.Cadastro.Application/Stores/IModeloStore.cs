using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IModeloStore
    {
        Task<int> InserirAsync(Modelo modelo);
        Task<bool> AtualizarAsync(Modelo modelo);
        Task<bool> ExcluirAsync(int id);
        Task<Modelo> BuscarPorIdAsync(int id);
        Task<IEnumerable<Modelo>> BuscarAsync(int skip = 0, int take = int.MaxValue);
        Task<IEnumerable<Modelo>> BuscarPorMarcaAsync(int idMarca, int skip = 0, int take = int.MaxValue);
    }
}
