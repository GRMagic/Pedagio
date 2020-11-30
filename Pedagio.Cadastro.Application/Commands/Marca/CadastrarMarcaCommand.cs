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
}
