using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;

[Route("posicoesProdutos")]
[ApiController]
public class PosicoesProdutosController : ControllerBase
{
    private IServico<PosicaoProduto> _servico;

    public PosicoesProdutosController(IServico<PosicaoProduto> servico)
    {
        _servico = servico;
    }

    // GET: PosicoesProdutos

    [HttpGet("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Index()
    {
        var posicaoproduto = await _servico.TodosAsync();
        return StatusCode(200, posicaoproduto);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "adm,editor")]
    public async Task<ActionResult> Details([FromRoute] int id)
    {
        var posicaoproduto = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, posicaoproduto);
    }

    // POST: PosicoesProdutos
    [HttpPost("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Create([FromBody] PosicaoProdutoDTO posicaoProdutoDTO)
    {
        var posicaoProduto = BuilderServico<PosicaoProduto>.Builder(posicaoProdutoDTO);
        await _servico.IncluirAsync(posicaoProduto);
        return StatusCode(201, posicaoProduto);
    }


    // PUT: PosicoesProdutos/5
    [HttpPut("{id}")]
    [Authorize(Roles = "adm")]
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

    // DELETE: PosicoesProdutos/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "adm")]
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