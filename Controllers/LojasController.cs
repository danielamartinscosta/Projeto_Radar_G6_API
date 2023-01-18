using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;


    [Route("lojas")]
    public class LojasController : ControllerBase
    {
        private IServico<Loja> _servico;
        public LojasController(IServico<Loja> servico)
        {
            _servico = servico;
        }

        // GET: Lojas

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var lojas = await _servico.TodosAsync();
            return StatusCode(200, lojas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var loja = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, loja);
        }

        // POST: Lojas
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] Loja loja)
        {
            await _servico.IncluirAsync(loja);
            return StatusCode(201, loja);
        }


        // PUT: Lojas/5
        [HttpPut("{id}")]
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

        // POST: Lojas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var lojaDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (lojaDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "A loja informado não existe"
                });
            }

            await _servico.ApagarAsync(lojaDb);

            return StatusCode(204);
        }
    }
