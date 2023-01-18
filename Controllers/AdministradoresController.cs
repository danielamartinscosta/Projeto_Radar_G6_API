using Microsoft.AspNetCore.Mvc;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;


[Route("administrador")]
    public class AdministradorController : ControllerBase
{
    private IServico<Administrador> _servico;

    public AdministradorController(IServico<Administrador> servico)
    {
        _servico = servico;
    }

    // GET: Clientes

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var administrador = await _servico.TodosAsync();
        return StatusCode(200, administrador);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var administrador = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, administrador);
    }

    // POST: Clientes
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] Administrador administrador)
    {
        await _servico.IncluirAsync(administrador);
        return StatusCode(201, administrador);
    }


    // PUT: Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Administrador administrador)
    {
        if (id != administrador.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id do administrador precisa bater com o id da URL"
            });
        }

        var administradorDb = await _servico.AtualizarAsync(administrador);

        return StatusCode(200, administradorDb);
    }

    // POST: Administrador/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var administradorDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
        if (administradorDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O administrador informado não existe"
            });
        }

        await _servico.ApagarAsync(administradorDb);

        return StatusCode(204);
    }
}


