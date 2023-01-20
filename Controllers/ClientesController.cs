using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;


    [Route("clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IServico<Cliente> _servico;

        public ClientesController(IServico<Cliente> servico)
        {
            _servico = servico;
        }

        // GET: Clientes

        [HttpGet("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Index()
        {
            var clientes = await _servico.TodosAsync();
            return StatusCode(200, clientes);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var cliente = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, cliente);
        }

        // POST: Clientes
        [HttpPost("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteDTO)
        {
            var cliente = BuilderServico<Cliente>.Builder(clienteDTO);
            await _servico.IncluirAsync(cliente);
            return StatusCode(201, cliente);
        }


        // PUT: Clientes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do cliente precisa bater com o id da URL"
                });
            }

            var clienteDb = await _servico.AtualizarAsync(cliente);

            return StatusCode(200, clienteDb);
        }

        // DELETE: Clientes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var clienteDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (clienteDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O cliente informado não existe"
                });
            }

            await _servico.ApagarAsync(clienteDb);

            return StatusCode(204);
        }
    }