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


[Route("pedidos")]
    public class PedidosController : ControllerBase
    {
        private IServico<Pedido> _servico;

        public PedidosController(IServico<Pedido> servico)
        {
            _servico = servico;
        }

        // GET: Pedidos

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var pedidos = await _servico.TodosAsync();
            return StatusCode(200, pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var pedido = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, pedido);
        }

        // POST: Pedidos
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] Pedido pedido)
        {
            await _servico.IncluirAsync(pedido);
            return StatusCode(201, pedido);
        }


        // PUT: Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do pedido precisa bater com o id da URL"
                });
            }

            var pedidoDb = await _servico.AtualizarAsync(pedido);

            return StatusCode(200, pedidoDb);
        }

        // POST: Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var pedidoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (pedidoDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O pedido informado não existe"
                });
            }

            await _servico.ApagarAsync(pedidoDb);

            return StatusCode(204);
        }
    }