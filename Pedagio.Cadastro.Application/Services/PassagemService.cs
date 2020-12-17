using Pedagio.Cadastro.Application.Utils;
using Pedagio.Cadastro.Data;
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

        public async Task<int> EfetuarPassagem(string placa)
        {
            var carro = await _carroStore.BuscarPorPlacaAsync(placa);
            if(carro == null)
            {
                throw new BusinessException("Não foi encontrado nenhum carro com essa placa.");
            }

            var passagem = new Passagem()
            {
                Carro = carro,
                Momento = DateTime.Now
            };

            return await _passagemStore.InserirAsync(passagem);
        }

        public async Task<int> RegistrarEvasao(string placa)
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

        public async Task<int> RegistrarEvasao(int idCarro)
        {
            var carro = await _carroStore.BuscarPorIdAsync(idCarro);
            if (carro == null)
            {
                throw new BusinessException("Não foi encontrado nenhum carro com o id informado.");
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
