using Pedagio.Cadastro.Application.Stores;
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

        public Task<IEnumerable<Carro>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return _carroStore.BuscarAsync(skip, take);
        }

        public Task<Carro> BuscarPorIdAsync(int id)
        {
            return _carroStore.BuscarPorIdAsync(id);
        }

        public Task<Carro> BuscarPorPlacaAsync(string placa)
        {
            return _carroStore.BuscarPorPlacaAsync(placa);
        }
    }
}
