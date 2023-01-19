using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class LojaRepositorio : IServico<Loja>
{
    private RadarContexto contexto;
    public LojaRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<Loja>> TodosAsync()
    {
        return await contexto.Lojas.ToListAsync();
    }

    public async Task IncluirAsync(Loja loja)
    {
        contexto.Lojas.Add(loja);
        await contexto.SaveChangesAsync();
    }

    public async Task<Loja> AtualizarAsync(Loja loja)
    {
        contexto.Entry(loja).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return loja;
    }

    public async Task ApagarAsync(Loja loja)
    {
        var obj = await contexto.Lojas.FindAsync(loja.Id);
        if(obj is null) throw new Exception("Loja não encontrado");
        contexto.Lojas.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
