﻿using MediatR;
using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Modelo
{
    public class CadastrarCarroCommandHandler : IRequestHandler<CadastrarCarroCommand, int>
    {
        private readonly ICarroStore _carroStore;

        public CadastrarCarroCommandHandler(ICarroStore carroStore)
        {
            _carroStore = carroStore;
        }

        public async Task<int> Handle(CadastrarCarroCommand request, CancellationToken cancellationToken)
        {
            return await _carroStore.InserirAsync(new Domain.Carro 
            {
                Placa = request.Placa,
                Ano = request.Ano,
                Modelo = new Domain.Modelo
                {
                    Id = request.IdModelo
                }
            });
        }
    }
}
