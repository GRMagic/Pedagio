﻿using MediatR;
using Pedagio.Cadastro.Application.Commands.Modelo;
using Pedagio.Cadastro.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Modelo
{
    public class ExcluirModeloCommandHandler : IRequestHandler<ExcluirModeloCommand, bool>
    {
        private readonly IModeloStore _modeloStore;

        public ExcluirModeloCommandHandler(IModeloStore modeloStore)
        {
            _modeloStore = modeloStore;
        }

        public async Task<bool> Handle(ExcluirModeloCommand request, CancellationToken cancellationToken)
        {
            return await _modeloStore.ExcluirAsync(request.Id);
        }
    }
}
