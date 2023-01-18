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

[Route("posicoesProdutos")]
public class PosicoesProdutosController : ControllerBase
{
    private IServico<PosicaoProduto> _servico;

    public PosicoesProdutosController(IServico<PosicaoProduto> servico)
    {
        _servico = servico;
    }

    // GET: PosicoesProdutos

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var posicaoproduto = await _servico.TodosAsync();
        return StatusCode(200, posicaoproduto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Details([FromRoute] int id)
    {
        var posicaoproduto = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, posicaoproduto);
    }

    // POST: PosicoesProdutos
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] PosicaoProduto posicaoproduto)
    {
        await _servico.IncluirAsync(posicaoproduto);
        return StatusCode(201, posicaoproduto);
    }


    // PUT: PosicoesProdutos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PosicaoProduto posicaoproduto)
    {
        if (id != posicaoproduto.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id da posicao do produto precisa bater com o id da URL"
            });
        }

        var posicaoprodutoDb = await _servico.AtualizarAsync(posicaoproduto);

        return StatusCode(200, posicaoprodutoDb);
    }

    // POST: PosicoesProdutos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var posicaoprodutoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
        if (posicaoprodutoDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "A posicao do produto informado não existe"
            });
        }

        await _servico.ApagarAsync(posicaoprodutoDb);

        return StatusCode(204);
    }
}