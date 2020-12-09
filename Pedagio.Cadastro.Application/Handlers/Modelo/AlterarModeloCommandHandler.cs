using MediatR;
using Pedagio.Cadastro.Application.Commands.Modelo;
using Pedagio.Cadastro.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Modelo
{
    public class AlterarModeloCommandHandler : IRequestHandler<AlterarModeloCommand, bool>
    {
        private readonly IModeloStore _modeloStore;

        public AlterarModeloCommandHandler(IModeloStore modeloStore)
        {
            _modeloStore = modeloStore;
        }

        public async Task<bool> Handle(AlterarModeloCommand request, CancellationToken cancellationToken)
        {
            return await _modeloStore.AtualizarAsync(new Domain.Modelo
            {
                Id = request.Id,
                Nome = request.Nome,
                Marca = new Domain.Marca
                {
                    Id = request.IdMarca
                }
            });
        }
    }
}
