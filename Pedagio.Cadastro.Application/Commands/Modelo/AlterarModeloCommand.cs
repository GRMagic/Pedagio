using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class AlterarModeloCommand : IRequest<bool>
    {
        /// <summary>
        /// Identificador do modelo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int IdMarca { get; set; }

        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }
    }

    public class AlterarModeloCommandValidation : AbstractValidator<AlterarModeloCommand>
    {
        public AlterarModeloCommandValidation()
        {

            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O Id do modelo é obrigatório.");

            RuleFor(c => c.IdMarca)
                .GreaterThan(0)
                .WithMessage("O Id da marca é obrigatório.");

            RuleFor(c => c.Nome)
                .MaximumLength(30)
                .WithMessage("O tamanho máximo para o nome do modelo é 30 caracteres.")
                .MinimumLength(1)
                .WithMessage("O nome do modelo é obrigatório.");
        }
    }
}
