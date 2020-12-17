using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedagio.Cadastro.Application.Commands.Passagem
{
    public class EfetuarPassagemCommand : IRequest<int>
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        public string Placa { get; set; }
    }

    public class EfetuarPassagemCommandValidation : AbstractValidator<EfetuarPassagemCommand>
    {
        public EfetuarPassagemCommandValidation()
        {
            RuleFor(c => c.Placa)
                .Length(7)
                .WithMessage("A placa do veículo deve ter 7 dígitos.");
        }
    }
}
