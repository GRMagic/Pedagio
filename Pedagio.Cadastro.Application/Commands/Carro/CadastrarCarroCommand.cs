using FluentValidation;
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

    public class CadastrarCarroCommandValidation : AbstractValidator<CadastrarCarroCommand>
    {
        public CadastrarCarroCommandValidation()
        {
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
