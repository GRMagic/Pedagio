using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface ICarroQueryStore
    {
        Task<Carro> BuscarPorIdAsync(int id);
        Task<Carro> BuscarPorPlacaAsync(string placa);
        Task<IEnumerable<Carro>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
