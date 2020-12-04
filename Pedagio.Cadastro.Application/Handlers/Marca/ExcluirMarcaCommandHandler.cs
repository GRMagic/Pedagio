using MediatR;
using Pedagio.Cadastro.Application.Commands.Marca;
using Pedagio.Cadastro.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Marca
{
    public class ExcluirMarcaCommandHandler : IRequestHandler<ExcluirMarcaCommand, bool>
    {
        private readonly IMarcaStore _marcaStore;

        public ExcluirMarcaCommandHandler(IMarcaStore marcaStore)
        {
            _marcaStore = marcaStore;
        }

        public async Task<bool> Handle(ExcluirMarcaCommand request, CancellationToken cancellationToken)
        {
            return await _marcaStore.ExcluirAsync(request.Id);
        }
    }
}
