using Pedagio.Cadastro.Data;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class ModeloQuery : IModeloQuery
    {
        private readonly IModeloStore _modeloStore;

        public ModeloQuery(IModeloStore modeloStore)
        {
            _modeloStore = modeloStore;
        }

        public async Task<IEnumerable<Modelo>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _modeloStore.BuscarAsync(skip, take);
        }

        public async Task<Modelo> BuscarPorIdAsync(int id)
        {
            return await _modeloStore.BuscarPorIdAsync(id);
        }
    }
}
