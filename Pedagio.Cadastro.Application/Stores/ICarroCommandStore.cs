using Pedagio.Cadastro.Domain;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface ICarroCommandStore
    {
        Task<int> InserirAsync(Carro carro);
        Task<bool> AtualizarAsync(Carro carro);
        Task<bool> ExcluirAsync(int id);
    }
}
