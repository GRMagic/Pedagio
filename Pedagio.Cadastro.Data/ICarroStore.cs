using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Data
{
    public interface ICarroStore
    {
        Task<int> InserirAsync(Carro carro);
        Task<bool> AtualizarAsync(Carro carro);
        Task<bool> ExcluirAsync(int id);
        Task<Carro> BuscarPorIdAsync(int id);
        Task<IEnumerable<Carro>> BuscarAsync(int skip = 0, int take = int.MaxValue);
    }
}
