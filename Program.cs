
//using Microsoft.EntityFrameworkCore;
//using RadarG6.Context;

using api.Repositorios.Entity;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*builder.Services.AddDbContext<RadarContexto>(options =>
    {

        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_RADAR_G6");
        if (conexao is null) conexao = "server=localhost;database=radar_g6;uid=root;pwd=2411dmcroot*";
        options.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

    });*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServico<Cliente>, ClienteRepositorio>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
