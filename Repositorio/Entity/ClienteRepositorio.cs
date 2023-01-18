using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace api.Repositorios.Entity;

public class ClienteRepositorio : IServico<Cliente>
{
    private RadarContexto contexto;
    public ClienteRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<Cliente>> TodosAsync()
    {
        return await contexto.Clientes.ToListAsync();
    }

    public async Task IncluirAsync(Cliente cliente)
    {
        contexto.Clientes.Add(cliente);
        await contexto.SaveChangesAsync();
    }

    public async Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        contexto.Entry(cliente).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return cliente;
    }

    public async Task ApagarAsync(Cliente cliente)
    {
        var obj = await contexto.Clientes.FindAsync(cliente.Id);
        if(obj is null) throw new Exception("Cliente não encontrado");
        contexto.Clientes.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
