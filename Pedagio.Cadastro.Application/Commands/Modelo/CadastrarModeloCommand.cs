using FluentValidation;
using MediatR;

namespace Pedagio.Cadastro.Application.Commands.Modelo
{
    public class CadastrarModeloCommand : IRequest<int>
    {
        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Identificador da marca
        /// </summary>
        public int IdMarca { get; set; }
    }

    public class CadastrarModeloCommandValidation : AbstractValidator<CadastrarModeloCommand>
    {
        public CadastrarModeloCommandValidation()
        {
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
