using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Marca
{
    public class AlterarMarcaCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da marca
        /// </summary>
        public string Nome { get; set; }
    }
}
