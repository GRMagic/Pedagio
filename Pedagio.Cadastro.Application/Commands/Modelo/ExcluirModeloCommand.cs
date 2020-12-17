using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class ExcluirModeloCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do modelo
        /// </summary>
        public int Id { get; set; }
    }

    public class ExcluirModeloCommandValidation : AbstractValidator<ExcluirModeloCommand>
    {
        public ExcluirModeloCommandValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id do modelo é obrigatório.");
        }
    }
}
