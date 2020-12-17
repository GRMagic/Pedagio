using FluentValidation;
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

    public class ExcluirCarroCommandValidation : AbstractValidator<ExcluirCarroCommand>
    {
        public ExcluirCarroCommandValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id do carro é obrigatório.");
        }
    }
}
