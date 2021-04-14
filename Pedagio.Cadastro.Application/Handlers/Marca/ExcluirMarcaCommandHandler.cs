using MediatR;
using Pedagio.Cadastro.Application.Commands.Marca;
using Pedagio.Cadastro.Application.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Marca
{
    public class ExcluirMarcaCommandHandler : IRequestHandler<ExcluirMarcaCommand, bool>
    {
        private readonly IMarcaCommandStore _marcaStore;

        public ExcluirMarcaCommandHandler(IMarcaCommandStore marcaStore)
        {
            _marcaStore = marcaStore;
        }

        public async Task<bool> Handle(ExcluirMarcaCommand request, CancellationToken cancellationToken)
        {
            return await _marcaStore.ExcluirAsync(request.Id);
        }
    }
}
