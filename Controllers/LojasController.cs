using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;


    [Route("lojas")]
    [ApiController]
    public class LojasController : ControllerBase
    {
        private IServico<Loja> _servico;
        public LojasController(IServico<Loja> servico)
        {
            _servico = servico;
        }

        // GET: Lojas

        [HttpGet("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Index()
        {
            var lojas = await _servico.TodosAsync();
            return StatusCode(200, lojas);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var loja = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, loja);
        }

        // POST: Lojas
        [HttpPost("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Create([FromBody] LojaDTO lojaDTO)
        {
            var loja = BuilderServico<Loja>.Builder(lojaDTO);
            await _servico.IncluirAsync(loja);
            return StatusCode(201, loja);
        }


        // PUT: Lojas/5
        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Loja loja)
        {
            if (id != loja.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id da loja precisa bater com o id da URL"
                });
            }

            var lojaDb = await _servico.AtualizarAsync(loja);

            return StatusCode(200, lojaDb);
        }

        // DELETE: Lojas/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var lojaDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (lojaDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "A loja informada não existe"
                });
            }

            await _servico.ApagarAsync(lojaDb);

            return StatusCode(204);
        }
    }
