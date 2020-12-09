using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Carro
{
    public class AlterarCarroCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do carro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador do modelo do carro
        /// </summary>
        public int IdModelo { get; set; }

        /// <summary>
        /// Placa do carro
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Ano do carro
        /// </summary>
        public int Ano { get; set; }
    }
}
