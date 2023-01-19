using api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadarG6.DTOs;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos;
using RadarG6.Servicos.Autenticacao;
using RadarWebApi.Models;

namespace RadarG6_webAPI.Controllers;


public class AdministradorController : ControllerBase
{
    private IServicoAdm<Administrador> _servico;

    public AdministradorController(IServicoAdm<Administrador> servico)
    {
        _servico = servico;
    }


    // POST: Administrador
    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AdministradorDTO administradorDTO)
    {
        if (string.IsNullOrEmpty(administradorDTO.Email) || string.IsNullOrEmpty(administradorDTO.Senha))
            return StatusCode(400, new
            {
                Mensagem = "Preencha o email e a senha"
            });

        var administrador = await _servico.Login(administradorDTO.Email, administradorDTO.Senha);
        if (administrador is null)
            return StatusCode(404, new
            {
                Mensagem = "Usuario ou senha não encontrado em nossa base de dados"
            });

        var administradorLogado = BuilderServico<AdministradorLogado>.Builder(administrador);
        administradorLogado.Token = TokenJWT.Builder(administradorLogado);

        return StatusCode(200, administradorLogado);
    }
}


