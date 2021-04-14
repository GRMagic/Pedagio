using Pedagio.Cadastro.Application.Stores;
using Pedagio.Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Queries
{
    public class PassagemQuery : IPassagemQuery
    {
        private readonly IPassagemQueryStore _passagemQueryStore;

        public PassagemQuery(IPassagemQueryStore passagemStore)
        {
            _passagemQueryStore = passagemStore;
        }

        public async Task<IEnumerable<Passagem>> BuscarAsync(int skip = 0, int take = int.MaxValue)
        {
            return await _passagemQueryStore.BuscarAsync(skip, take);
        }

        public async Task<Passagem> BuscarPorIdAsync(int id)
        {
            return await _passagemQueryStore.BuscarPorIdAsync(id);
        }

        public async Task<IEnumerable<Passagem>> BuscarPorCarroAsync(int idCarro, DateTime inicio, DateTime fim)
        {
            return await _passagemQueryStore.BuscarPorCarroAsync(idCarro, inicio, fim);
        }
    }
}
