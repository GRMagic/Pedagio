using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IMarcaQueryStore
    {
        Task<Marca> BuscarPorIdAsync(int id);
        Task<IEnumerable<Marca>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
