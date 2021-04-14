using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class ModeloQuery : IModeloQuery
    {
        private readonly IModeloQueryStore _modeloQueryStore;

        public ModeloQuery(IModeloQueryStore modeloStore)
        {
            _modeloQueryStore = modeloStore;
        }

        public async Task<IEnumerable<Modelo>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _modeloQueryStore.BuscarAsync(skip, take);
        }

        public async Task<IEnumerable<Modelo>> BuscarPorMarcaAsync(int idMarca, int skip = 0, int take = int.MaxValue)
        {
            return await _modeloQueryStore.BuscarPorMarcaAsync(idMarca, skip, take);
        }

        public async Task<Modelo> BuscarPorIdAsync(int id)
        {
            return await _modeloQueryStore.BuscarPorIdAsync(id);
        }
    }
}
