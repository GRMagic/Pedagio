using Pedagio.Cadastro.Data;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class CarroQuery : ICarroQuery
    {
        private readonly ICarroStore _carroStore;

        public CarroQuery(ICarroStore carroStore)
        {
            _carroStore = carroStore;
        }

        public async Task<IEnumerable<Carro>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _carroStore.BuscarAsync(skip, take);
        }

        public async Task<Carro> BuscarPorIdAsync(int id)
        {
            return await _carroStore.BuscarPorIdAsync(id);
        }
    }
}
