using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Carro
{
    public class CadastrarCarroCommand : IRequest<int>
    {
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
