using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Cadastro.Application.Commands.Marca;
using Pedagio.Cadastro.Data;
using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaStore _marcaStore;
        private readonly IMediator _mediator;

        public MarcaController(IMarcaStore marcaStore, IMediator mediator)
        {
            _marcaStore = marcaStore;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todas as marcas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Marca>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marca = await _marcaStore.BuscarAsync();
                return Ok(marca);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Busca uma marca específica
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <returns>Dados da marca</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Marca), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var marca = await _marcaStore.BuscarPorIdAsync(id);
                if (marca == null) return NotFound();

                return Ok(marca);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Grava uma nova Marca
        /// </summary>
        /// <param name="command">Dados da marca</param>
        /// <returns>Identificador da marca gravada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CadastrarMarcaCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza uma marca
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <param name="marca">Dados da marca</param>
        /// <returns>Dados da marca</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Marca), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Marca marca)
        {
            try
            {

                marca.Id = id;
                if(await _marcaStore.AtualizarAsync(marca))
                {
                    return Ok(marca);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Exclui uma marca
        /// </summary>
        /// <param name="id">Identificador da marca</param>
        /// <returns>Status 200 para sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _marcaStore.ExcluirAsync(id))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
