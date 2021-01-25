using MediatR;
using Pedagio.Cadastro.Application.Commands.Passagem;
using Pedagio.Cadastro.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Passagem
{
    public class EfetuarPassagemCommandHandler : IRequestHandler<EfetuarPassagemCommand, int>
    {
        private IPassagemService _passagemService;

        public EfetuarPassagemCommandHandler(IPassagemService passagemService)
        {
            _passagemService = passagemService;
        }

        public async Task<int> Handle(EfetuarPassagemCommand request, CancellationToken cancellationToken)
        {
            return await _passagemService.EfetuarPassagemAsync(request.Placa);
        }
    }
}
