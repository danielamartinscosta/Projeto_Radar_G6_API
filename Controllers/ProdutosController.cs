using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;

[Route("produtos")]
[ApiController]
    public class ProdutosController : ControllerBase
    { 
        private IServico<Produto> _servico;
        public ProdutosController(IServico<Produto> servico)
        {
            _servico = servico;
        }

        // GET: Produtos

        [HttpGet("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Index()
        {
            var produto = await _servico.TodosAsync();
            return StatusCode(200, produto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var produto = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, produto);
        }

        // POST: Produtos
        [HttpPost("")]
        [Authorize(Roles = "adm,editor")]
        public async Task<IActionResult> Create([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = BuilderServico<Produto>.Builder(produtoDTO);
            await _servico.IncluirAsync(produto);
            return StatusCode(201, produto);
        }


        // PUT: Produtos/5
        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do produto precisa bater com o id da URL"
                });
            }

            var produtoDb = await _servico.AtualizarAsync(produto);

            return StatusCode(200, produtoDb);
        }

        // DELETE: Produtos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var produtoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (produtoDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O produto informado não existe"
                });
            }

            await _servico.ApagarAsync(produtoDb);

            return StatusCode(204);
        }
    }