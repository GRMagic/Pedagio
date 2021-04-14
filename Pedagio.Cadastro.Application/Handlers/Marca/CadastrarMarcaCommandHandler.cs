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
    public class CadastrarMarcaCommandHandler : IRequestHandler<CadastrarMarcaCommand, int>
    {
        private readonly IMarcaCommandStore _marcaStore;

        public CadastrarMarcaCommandHandler(IMarcaCommandStore marcaStore)
        {
            _marcaStore = marcaStore;
        }

        public async Task<int> Handle(CadastrarMarcaCommand request, CancellationToken cancellationToken)
        {
            return await _marcaStore.InserirAsync(new Domain.Marca 
            {
                Nome = request.Nome 
            });
        }
    }
}
