using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Marca
{
    public class ExcluirMarcaCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int Id { get; set; }
    }

    public class ExcluirMarcaCommandValidation : AbstractValidator<ExcluirMarcaCommand>
    {
        public ExcluirMarcaCommandValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id da marca é obrigatório.");
        }
    }
}
