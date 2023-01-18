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

[Route("pedidosProdutos")]
public class PedidosProdutosController : ControllerBase
{
    private IServico<PedidoProduto> _servico;
    public PedidosProdutosController(IServico<PedidoProduto> servico)
    {
        _servico = servico;
    }

    // GET: PedidosProdutos

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var pedidoProduto = await _servico.TodosAsync();
        return StatusCode(200, pedidoProduto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var pedidoProduto = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, pedidoProduto);
    }

    // POST: PedidosProdutos
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] PedidoProduto pedidoProduto)
    {
        await _servico.IncluirAsync(pedidoProduto);
        return StatusCode(201, pedidoProduto);
    }


    // PUT: PedidosProdutos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PedidoProduto pedidoProduto)
    {
        if (id != pedidoProduto.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id do pedido de produto precisa bater com o id da URL"
            });
        }

        var pedidoProdutoDb = await _servico.AtualizarAsync(pedidoProduto);

        return StatusCode(200, pedidoProdutoDb);
    }

    // POST: PedidoProduto/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var pedidoProdutoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
        if (pedidoProdutoDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O Pedido de produtos informado não existe"
            });
        }

        await _servico.ApagarAsync(pedidoProdutoDb);

        return StatusCode(204);
    }
}