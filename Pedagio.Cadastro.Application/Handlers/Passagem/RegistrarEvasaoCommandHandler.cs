using MediatR;
using Pedagio.Cadastro.Application.Commands.Passagem;
using Pedagio.Cadastro.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Pedagio.Cadastro.Application.Handlers.Passagem
{
    public class RegistrarEvasaoCommandHandler : IRequestHandler<RegistrarEvasaoCommand, int>
    {
        private IPassagemService _passagemService;

        public RegistrarEvasaoCommandHandler(IPassagemService passagemService)
        {
            _passagemService = passagemService;
        }

        public async Task<int> Handle(RegistrarEvasaoCommand request, CancellationToken cancellationToken)
        {
            if(request.IdCarro > 0)
            {
                return await _passagemService.RegistrarEvasao(request.IdCarro);
            }
            else
            {
                return await _passagemService.RegistrarEvasao(request.Placa);
            }
        }
    }
}
