using Pedagio.Cadastro.Domain;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IPassagemCommandStore
    {
        Task<int> InserirAsync(Passagem passagem);
        Task<bool> AtualizarAsync(Passagem passagem);
        Task<bool> ExcluirAsync(int id);
    }
}
