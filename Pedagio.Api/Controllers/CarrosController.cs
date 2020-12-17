using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Api.ViewModels;
using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo cadastro de carros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICarroQuery _carroQuery;
        private readonly IPassagemQuery _passagemQuery;

        public CarrosController(ICarroQuery carroQuery, IPassagemQuery passagemQuery, IMediator mediator)
        {
            _carroQuery = carroQuery;
            _passagemQuery = passagemQuery;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os carros
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CarroViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var carros = (await _carroQuery.BuscarAsync()).Select(c => new CarroViewModel(c));
            return Ok(carros);
        }

        /// <summary>
        /// Busca um carro específico
        /// </summary>
        /// <param name="id">Identificador do carro</param>
        /// <returns>Dados da carro</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CarroViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var carro = await _carroQuery.BuscarPorIdAsync(id);
            if (carro == null) return NotFound();

            return Ok(new CarroViewModel(carro));
        }

        /// <summary>
        /// Busca um carro pela placa
        /// </summary>
        /// <param name="placa">placa do carro</param>
        /// <returns>Dados da carro</returns>
        [HttpGet("Placa/{placa}")]
        [ProducesResponseType(typeof(CarroViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string placa)
        {
            var carro = await _carroQuery.BuscarPorPlacaAsync(placa);
            if (carro == null) return NotFound();

            return Ok(new CarroViewModel(carro));
        }

        /// <summary>
        /// Grava um novo Carro
        /// </summary>
        /// <param name="command">Dados do carro</param>
        /// <returns>Identificador do carro gravado</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CadastrarCarroCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction("Get", new { id }, command);
        }

        /// <summary>
        /// Atualiza um carro
        /// </summary>
        /// <param name="id">Identificador do carro</param>
        /// <param name="command">Dados do carro</param>
        /// <returns>Dados do carro</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AlterarCarroCommand command)
        {
            command.Id = id;
            if (await _mediator.Send(command))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Exclui um carro
        /// </summary>
        /// <param name="id">Identificador do carro</param>
        /// <returns>Status 200 para sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ExcluirCarroCommand() { Id = id };
            if (await _mediator.Send(command))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lista as passagens de um carro
        /// </summary>
        /// <param name="id">Identificador do carro</param>
        /// <param name="inicio">Data para início do filtro</param>
        /// <param name="fim">Data para Fim do filtro</param>
        /// <returns></returns>
        [HttpGet("{id}/Passagens")]
        [ProducesResponseType(typeof(IEnumerable<PassagemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Passagens(int id, [FromQuery] DateTime? inicio = null, [FromQuery] DateTime? fim = null)
        {
            var passagens = await _passagemQuery.BuscarPorCarroAsync(id, inicio ?? new DateTime(), fim ?? DateTime.MaxValue);
            
            return Ok(passagens.Select(p => new PassagemViewModel(p)));
        }
    }
}
