using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class CadastrarModeloCommand : IRequest<int>
    {
        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int IdMarca { get; set; }
    }
}
