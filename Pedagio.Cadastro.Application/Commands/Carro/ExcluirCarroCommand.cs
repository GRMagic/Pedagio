using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Carro
{
    public class ExcluirCarroCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do carro
        /// </summary>
        public int Id { get; set; }
    }
}
