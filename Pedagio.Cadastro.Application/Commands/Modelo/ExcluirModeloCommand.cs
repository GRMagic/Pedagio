using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class ExcluirModeloCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do modelo
        /// </summary>
        public int Id { get; set; }
    }
}
