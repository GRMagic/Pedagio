using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class MarcaQuery : IMarcaQuery
    {
        private readonly IMarcaQueryStore _marcaQueryStore;

        public MarcaQuery(IMarcaQueryStore marcaStore)
        {
            _marcaQueryStore = marcaStore;
        }

        public async Task<IEnumerable<Marca>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _marcaQueryStore.BuscarAsync(skip, take);
        }

        public async Task<Marca> BuscarPorIdAsync(int id)
        {
            return await _marcaQueryStore.BuscarPorIdAsync(id);
        }
    }
}
