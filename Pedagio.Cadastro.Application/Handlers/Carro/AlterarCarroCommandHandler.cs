﻿using MediatR;
using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Application.Stores;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Modelo
{
    public class AlterarCarroCommandHandler : IRequestHandler<AlterarCarroCommand, bool>
    {
        private readonly ICarroCommandStore _carroStore;

        public AlterarCarroCommandHandler(ICarroCommandStore carroStore)
        {
            _carroStore = carroStore;
        }

        public async Task<bool> Handle(AlterarCarroCommand request, CancellationToken cancellationToken)
        {
            return await _carroStore.AtualizarAsync(new Domain.Carro
            {
                Id = request.Id,
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
