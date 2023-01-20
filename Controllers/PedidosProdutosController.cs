using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;

[Route("pedidosProdutos")]
[ApiController]
public class PedidosProdutosController : ControllerBase
{
    private IServico<PedidoProduto> _servico;
    public PedidosProdutosController(IServico<PedidoProduto> servico)
    {
        _servico = servico;
    }

    // GET: PedidosProdutos

    [HttpGet("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Index()
    {
        var pedidoProduto = await _servico.TodosAsync();
        return StatusCode(200, pedidoProduto);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var pedidoProduto = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, pedidoProduto);
    }

    // POST: PedidosProdutos
    [HttpPost("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Create([FromBody] PedidoProdutoDTO pedidoProdutoDTO)
    {
        var pedidoProduto = BuilderServico<PedidoProduto>.Builder(pedidoProdutoDTO);
        await _servico.IncluirAsync(pedidoProduto);
        return StatusCode(201, pedidoProduto);
    }


    // PUT: PedidosProdutos/5
    [HttpPut("{id}")]
    [Authorize(Roles = "adm")]
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

    // DELETE: PedidoProduto/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "adm")]
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