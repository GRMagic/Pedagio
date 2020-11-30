using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public interface IMarcaStore
    {
        Task<int> InserirAsync(Marca marca);
        Task<bool> AtualizarAsync(Marca marca);
        Task<bool> ExcluirAsync(int id);
        Task<Marca> BuscarPorIdAsync(int id);
        Task<IEnumerable<Marca>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
