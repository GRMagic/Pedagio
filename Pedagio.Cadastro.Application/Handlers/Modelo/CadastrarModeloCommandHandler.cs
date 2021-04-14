using MediatR;
using Pedagio.Cadastro.Application.Commands.Modelo;
using Pedagio.Cadastro.Application.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Modelo
{
    public class CadastrarModeloCommandHandler : IRequestHandler<CadastrarModeloCommand, int>
    {
        private readonly IModeloStore _modeloStore;

        public CadastrarModeloCommandHandler(IModeloStore modeloStore)
        {
            _modeloStore = modeloStore;
        }

        public async Task<int> Handle(CadastrarModeloCommand request, CancellationToken cancellationToken)
        {
            return await _modeloStore.InserirAsync(new Domain.Modelo 
            {
                Nome = request.Nome,
                Marca = new Domain.Marca
                {
                    Id = request.IdMarca    
                }
            });
        }
    }
}
