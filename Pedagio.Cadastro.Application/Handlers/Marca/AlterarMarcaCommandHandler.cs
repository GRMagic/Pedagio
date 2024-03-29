﻿using MediatR;
using Pedagio.Cadastro.Application.Commands.Marca;
using Pedagio.Cadastro.Application.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Marca
{
    public class AlterarMarcaCommandHandler : IRequestHandler<AlterarMarcaCommand, bool>
    {
        private readonly IMarcaCommandStore _marcaStore;

        public AlterarMarcaCommandHandler(IMarcaCommandStore marcaStore)
        {
            _marcaStore = marcaStore;
        }

        public async Task<bool> Handle(AlterarMarcaCommand request, CancellationToken cancellationToken)
        {
            return await _marcaStore.AtualizarAsync(new Domain.Marca
            {
                Id = request.Id,
                Nome = request.Nome
            });
        }
    }
}
