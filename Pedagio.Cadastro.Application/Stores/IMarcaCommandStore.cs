using Pedagio.Cadastro.Domain;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IMarcaCommandStore
    {
        Task<int> InserirAsync(Marca marca);
        Task<bool> AtualizarAsync(Marca marca);
        Task<bool> ExcluirAsync(int id);
    }
}
