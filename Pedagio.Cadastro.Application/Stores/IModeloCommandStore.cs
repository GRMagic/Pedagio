using Pedagio.Cadastro.Domain;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IModeloCommandStore
    {
        Task<int> InserirAsync(Modelo modelo);
        Task<bool> AtualizarAsync(Modelo modelo);
        Task<bool> ExcluirAsync(int id);
    }
}
