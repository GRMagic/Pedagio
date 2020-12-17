using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Api.ViewModels;
using Pedagio.Cadastro.Application.Commands.Modelo;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Domain;

namespace Pedagio.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo cadastro de modelos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IModeloQuery _modeloQuery;

        public ModelosController(IModeloQuery modeloQuery, IMediator mediator)
        {
            _modeloQuery = modeloQuery;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os modelos
        /// </summary>
        /// <returns>Lista de modelos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModeloViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var modelo = (await _modeloQuery.BuscarAsync()).Select(m => new ModeloViewModel(m));
            return Ok(modelo);
        }

        /// <summary>
        /// Busca um modelo específico
        /// </summary>
        /// <param name="id">Identificador do modelo</param>
        /// <returns>Dados da modelo</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ModeloViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var modelo = await _modeloQuery.BuscarPorIdAsync(id);
            if (modelo == null) return NotFound();

            return Ok(new ModeloViewModel(modelo));
        }

        /// <summary>
        /// Grava um novo Modelo
        /// </summary>
        /// <param name="command">Dados do modelo</param>
        /// <returns>Identificador do modelo gravado</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CadastrarModeloCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction("Get", new { id }, command);
        }

        /// <summary>
        /// Atualiza um modelo
        /// </summary>
        /// <param name="id">Identificador do modelo</param>
        /// <param name="command">Dados do modelo</param>
        /// <returns>Dados do modelo</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] AlterarModeloCommand command)
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
        /// Exclui um modelo
        /// </summary>
        /// <param name="id">Identificador do modelo</param>
        /// <returns>Status 200 para sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ExcluirModeloCommand() { Id = id };
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
