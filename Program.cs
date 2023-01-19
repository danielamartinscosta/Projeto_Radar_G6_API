using System.Text;
using api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Radar.Repositorios;
using RadarG6.Repositorios.Interfaces;
using RadarG6.Servicos.Autenticacao;
using RadarWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServico<Cliente>, ClienteRepositorio>();
builder.Services.AddScoped<IServicoAdm<Administrador>, AdministradorRepositorio>();
builder.Services.AddScoped<IServico<Campanha>, CampanhaRepositorio>();
builder.Services.AddScoped<IServico<Produto>, ProdutoRepositorio>();
builder.Services.AddScoped<IServico<Pedido>, PedidoRepositorio>();
builder.Services.AddScoped<IServico<PedidoProduto>, PedidoProdutoRepositorio>();
builder.Services.AddScoped<IServico<Loja>, LojaRepositorio>();
builder.Services.AddScoped<IServico<PosicaoProduto>, PosicaoProdutoRepositorio>();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenJWT.Key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adm", policy => policy.RequireClaim("adm"));
    options.AddPolicy("editor", policy => policy.RequireClaim("editor"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
