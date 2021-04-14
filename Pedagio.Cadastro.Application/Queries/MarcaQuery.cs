using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class MarcaQuery : IMarcaQuery
    {
        private readonly IMarcaStore _marcaStore;

        public MarcaQuery(IMarcaStore marcaStore)
        {
            _marcaStore = marcaStore;
        }

        public async Task<IEnumerable<Marca>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _marcaStore.BuscarAsync(skip, take);
        }

        public async Task<Marca> BuscarPorIdAsync(int id)
        {
            return await _marcaStore.BuscarPorIdAsync(id);
        }
    }
}
