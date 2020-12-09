using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public interface IModeloStore
    {
        Task<int> InserirAsync(Modelo modelo);
        Task<bool> AtualizarAsync(Modelo modelo);
        Task<bool> ExcluirAsync(int id);
        Task<Modelo> BuscarPorIdAsync(int id);
        Task<IEnumerable<Modelo>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
