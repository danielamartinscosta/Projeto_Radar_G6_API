using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarWebApi.DTOs;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;

[Route("campanha")]
[ApiController]

public class CampanhasController : ControllerBase
{
    private IServico<Campanha> _servico;
    public CampanhasController(IServico<Campanha> servico)
    {
        _servico = servico;
    }

    // GET: Campanhas

    [HttpGet("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Index()
    {
        var campanha = await _servico.TodosAsync();
        return StatusCode(200, campanha);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var campanha = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, campanha);
    }

    // POST: Campanhas
    [HttpPost("")]
    [Authorize(Roles = "adm,editor")]
    public async Task<IActionResult> Create([FromBody] CampanhaDTO campanhaDTO)
    {
        var campanha = BuilderServico<Campanha>.Builder(campanhaDTO);
        await _servico.IncluirAsync(campanha);
        return StatusCode(201, campanha);
    }


    // PUT: Campanhas/5
    [HttpPut("{id}")]
    [Authorize(Roles = "adm")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Campanha campanha)
    {
        if (id != campanha.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id da campanha precisa bater com o id da URL"
            });
        }

        var campanhaDb = await _servico.AtualizarAsync(campanha);

        return StatusCode(200, campanhaDb);
    }

    // DELETE: Campanhas/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "adm")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var campanhaDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
        if (campanhaDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "A campanha informado não existe"
            });
        }

            await _servico.ApagarAsync(campanhaDb);

        return StatusCode(204);
    }
}


