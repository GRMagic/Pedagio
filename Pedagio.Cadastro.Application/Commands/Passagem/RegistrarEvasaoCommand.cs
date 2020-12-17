using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Passagem
{
    public class RegistrarEvasaoCommand : IRequest<int>
    {
        /// <summary>
        /// Identificador do carro
        /// </summary>
        public int IdCarro { get; set; }

        /// <summary>
        /// Placa do carro
        /// </summary>
        public string Placa { get; set; }
    }

    public class RegistrarEvasaoCommandValidation : AbstractValidator<RegistrarEvasaoCommand>
    {
        public RegistrarEvasaoCommandValidation()
        {
            RuleFor(c => c.IdCarro)
                .GreaterThan(0)
                .When(c => string.IsNullOrWhiteSpace(c.Placa))
                .WithMessage("Informe pelo menos um dos campos, IdCarro ou Placa");

            RuleFor(c => c.Placa)
                .Length(7)
                .WithMessage("A placa do veículo deve ter 7 dígitos.");
        }
    }
}
