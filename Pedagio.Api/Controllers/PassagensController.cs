using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Api.ViewModels;
using Pedagio.Cadastro.Application.Commands.Passagem;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Pedagio.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo passagem dos carros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PassagensController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPassagemQuery _passagemQuery;

        public PassagensController(IMediator mediator, IPassagemQuery passagemQuery)
        {
            _mediator = mediator;
            _passagemQuery = passagemQuery;
        }

        /// <summary>
        /// Lista todas as passagens
        /// </summary>
        /// <returns>Lista de passagens</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PassagemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Listar()
        {
            var passagem = (await _passagemQuery.BuscarAsync()).Select(p => new PassagemViewModel(p));
            return Ok(passagem);
        }

        /// <summary>
        /// Busca uma passagem específica
        /// </summary>
        /// <param name="id">Identificador da passagem</param>
        /// <returns>Dados da passagem</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PassagemViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Buscar(int id)
        {
            var passagem = await _passagemQuery.BuscarPorIdAsync(id);
            if (passagem == null) return NotFound();

            return Ok(new PassagemViewModel(passagem));
        }

        /// <summary>
        /// Efetua a passagem de um carro no momento que ela ocorre
        /// </summary>
        /// <param name="command">Dados da passagem</param>
        /// <returns>Identificador da passagem registrada</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> EfetuarPassagem([FromBody] EfetuarPassagemCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction("Buscar", new { id }, command);
        }

        /// <summary>
        /// Registra a evasão de um carro no momento que ela ocorre
        /// </summary>
        /// <param name="command">Dados da evasão</param>
        /// <returns>Identificador da evasão registrada</returns>
        [HttpPost("Evasao")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegistarEvasao([FromBody] RegistrarEvasaoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction("Buscar", new { id }, command);
        }
    }
}
