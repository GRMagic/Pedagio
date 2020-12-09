﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Cadastro.Application.Commands.Carro;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Application.ViewModels;
using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICarroQuery _carroQuery;

        public CarrosController(ICarroQuery carroQuery, IMediator mediator)
        {
            _carroQuery = carroQuery;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os carros
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Carro>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var carro = await _carroQuery.BuscarAsync();
            return Ok(carro);
        }

        /// <summary>
        /// Busca um carro específico
        /// </summary>
        /// <param name="id">Identificador do carro</param>
        /// <returns>Dados da carro</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Carro), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var carro = await _carroQuery.BuscarPorIdAsync(id);
            if (carro == null) return NotFound();

            return Ok(carro);
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
        /// <param name="model">Dados do carro</param>
        /// <returns>Dados do carro</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AlterarCarroViewModel model)
        {
            var command = new AlterarCarroCommand
            {
                Id = id,
                Placa = model.Placa,
                Ano = model.Ano,
                IdModelo = model.IdModelo
            };
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
    }
}