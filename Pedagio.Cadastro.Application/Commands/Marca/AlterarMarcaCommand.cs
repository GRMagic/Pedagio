using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Marca
{
    public class AlterarMarcaCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da marca
        /// </summary>
        public string Nome { get; set; }
    }

    public class AlterarMarcaCommandValidation : AbstractValidator<AlterarMarcaCommand>
    {
        public AlterarMarcaCommandValidation()
        {

            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id da marca é obrigatório.");

            RuleFor(c => c.Nome)
                .MaximumLength(30)
                .WithMessage("O tamanho máximo para o nome da marca é 30 caracteres.")
                .MinimumLength(1)
                .WithMessage("O nome da marca é obrigatório.");
        }
    }
}
