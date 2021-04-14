using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Application.Utils;
using Pedagio.Cadastro.Domain;
using System;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Services
{
    public class PassagemService : IPassagemService
    {
        private readonly IPassagemStore _passagemStore;
        private readonly ICarroStore _carroStore;

        public PassagemService(IPassagemStore passagemStore, ICarroStore carroStore)
        {
            _passagemStore = passagemStore;
            _carroStore = carroStore;
        }

        public async Task<int> EfetuarPassagemAsync(string placa)
        {
            var carro = await _carroStore.BuscarPorPlacaAsync(placa);
            if(carro == null)
            {
                throw new BusinessException(Language.Mensagens.ErroPlacaNaoEncontrada);
            }

            var passagem = new Passagem()
            {
                Carro = carro,
                Momento = DateTime.Now
            };

            return await _passagemStore.InserirAsync(passagem);
        }

        public async Task<int> RegistrarEvasaoAsync(string placa)
        {
            var carro = await _carroStore.BuscarPorPlacaAsync(placa);
            if (carro == null)
            {
                carro = new Carro
                {
                    Placa = placa
                };
                carro.Id = await _carroStore.InserirAsync(carro);
            }

            return await RegistrarEvasao(carro);
        }

        public async Task<int> RegistrarEvasaoAsync(int idCarro)
        {
            var carro = await _carroStore.BuscarPorIdAsync(idCarro);
            if (carro == null)
            {
                throw new BusinessException(Language.Mensagens.ErroIdCarroNaoEncontrado);
            }

            return await RegistrarEvasao(carro);
        }

        private async Task<int> RegistrarEvasao(Carro carro)
        {
            var passagem = new Passagem()
            {
                Carro = carro,
                Momento = DateTime.Now,
                Evasao = true
            };

            return await _passagemStore.InserirAsync(passagem);
        }
    }
}
