using FluentValidation;
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

    public class AlterarCarroCommandValidation : AbstractValidator<AlterarCarroCommand>
    {
        public AlterarCarroCommandValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id do carro é obrigatório.");

            RuleFor(c => c.Placa)
                .Length(7)
                .WithMessage("A placa deve ter 7 dígitos.");

            RuleFor(c => c.Ano)
                .GreaterThan(0)
                .WithMessage("O ano deve ser maior que zero.");

            RuleFor(c => c.IdModelo)
                .GreaterThan(0)
                .WithMessage("O modelo é obrigatório.");
        }
    }
}
