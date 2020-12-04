using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Marca
{
    public class ExcluirMarcaCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int Id { get; set; }
    }
}
