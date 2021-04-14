using MediatR;
using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Application.Stores;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Carro
{
    public class ExcluirCarroCommandHandler : IRequestHandler<ExcluirCarroCommand, bool>
    {
        private readonly ICarroCommandStore _carroStore;

        public ExcluirCarroCommandHandler(ICarroCommandStore carroStore)
        {
            _carroStore = carroStore;
        }

        public async Task<bool> Handle(ExcluirCarroCommand request, CancellationToken cancellationToken)
        {
            return await _carroStore.ExcluirAsync(request.Id);
        }
    }
}
