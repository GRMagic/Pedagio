﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedagio.Cadastro.Application.Commands.Marca
{
    public class CadastrarMarcaCommand : IRequest<int>
    {
        /// <summary>
        /// Nome da marca
        /// </summary>
        public string Nome { get; set; }
    }

    public class CadastrarMarcaCommandValidation : AbstractValidator<CadastrarMarcaCommand>
    {
        public CadastrarMarcaCommandValidation()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(30)
                .WithMessage("O tamanho máximo para o nome da marca é 30 caracteres.")
                .MinimumLength(1)
                .WithMessage("O nome da marca é obrigatório.");
        }
    }
}
