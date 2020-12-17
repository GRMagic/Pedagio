using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Cadastro.Application.Commands.Marca;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Application.ViewModels;
using Pedagio.Cadastro.Data;
using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo cadastro de marcas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMarcaQuery _marcaQuery;
        private readonly IModeloQuery _modeloQuery;

        public MarcasController(IMarcaQuery marcaQuery, IModeloQuery modeloQuery, IMediator mediator)
        {
            _marcaQuery = marcaQuery;
            _modeloQuery = modeloQuery;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todas as marcas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Marca>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var marca = await _marcaQuery.BuscarAsync();
            return Ok(marca);
        }

        /// <summary>
        /// Busca uma marca específica
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <returns>Dados da marca</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Marca), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var marca = await _marcaQuery.BuscarPorIdAsync(id);
            if (marca == null) return NotFound();

            return Ok(marca);
        }

        /// <summary>
        /// Lista os modelos de uma marca específica
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <returns>Lista de modelos</returns>
        [HttpGet("{id}/Modelos")]
        [ProducesResponseType(typeof(IEnumerable<Modelo>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetModelos(int id)
        {
            var marca = await _modeloQuery.BuscarPorMarcaAsync(id);
            if (marca == null) return NotFound();

            return Ok(marca);
        }

        /// <summary>
        /// Grava uma nova Marca
        /// </summary>
        /// <param name="command">Dados da marca</param>
        /// <returns>Identificador da marca gravada</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CadastrarMarcaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction("Get", new { id }, command);
        }

        /// <summary>
        /// Atualiza uma marca
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <param name="model">Dados da marca</param>
        /// <returns>Dados da marca</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AlterarMarcaViewModel model)
        {
            var command = new AlterarMarcaCommand
            {
                Id = id,
                Nome = model.Nome
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
        /// Exclui uma marca
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <returns>Status 200 para sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ExcluirMarcaCommand() { Id = id };
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
