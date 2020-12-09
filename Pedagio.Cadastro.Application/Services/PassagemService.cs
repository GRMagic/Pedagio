using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Services
{
    public class PassagemService : IPassagemService
    {
        public async Task<bool> RegistrarPassagem(int idVeiculo)
        {
            return idVeiculo > 0;
        }
    }
}
