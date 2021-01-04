//using Pedagio.Cadastro.Data;
//using Pedagio.Cadastro.Domain;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Pedagio.Cadastro.Application.Queries
//{
//    public class PassagemQuery : IPassagemQuery
//    {
//        private readonly IPassagemStore _passagemStore;

//        public PassagemQuery(IPassagemStore passagemStore)
//        {
//            _passagemStore = passagemStore;
//        }

//        public async Task<IEnumerable<Passagem>> BuscarAsync(int skip = 0, int take = int.MaxValue)
//        {
//            return await _passagemStore.BuscarAsync(skip, take);
//        }

//        public async Task<Passagem> BuscarPorIdAsync(int id)
//        {
//            return await _passagemStore.BuscarPorIdAsync(id);
//        }

//        public async Task<IEnumerable<Passagem>> BuscarPorCarroAsync(int idCarro, DateTime inicio, DateTime fim)
//        {
//            return await _passagemStore.BuscarPorCarroAsync(idCarro, inicio, fim);
//        }
//    }
//}
