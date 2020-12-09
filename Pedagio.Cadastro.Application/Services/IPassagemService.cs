using Pedagio.Cadastro.Domain;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Services
{

    public interface IPassagemService
    {
        /// <summary>
        /// Registra a passagem de um veículo
        /// </summary>
        /// <param name="idVeiculo">Identificador do veículo</param>
        /// <returns>true caso a passagem tenha sido registrada e false caso não tenha registrado a passagem</returns>
        Task<bool> RegistrarPassagem(int idVeiculo);
    }
}
