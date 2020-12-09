using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class AlterarModeloCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do modelo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int IdMarca { get; set; }

        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }
    }
}
