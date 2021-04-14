using Pedagio.Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Stores
{
    public interface IPassagemQueryStore
    {
        Task<Passagem> BuscarPorIdAsync(int id);
        Task<IEnumerable<Passagem>> BuscarAsync(int skip = 0, int take = int.MaxValue);
        Task<IEnumerable<Passagem>> BuscarPorCarroAsync(int idCarro, DateTime inicio, DateTime fim);
    }
}
