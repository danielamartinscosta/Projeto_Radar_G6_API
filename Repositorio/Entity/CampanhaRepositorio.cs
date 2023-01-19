using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class CampanhaRepositorio : IServico<Campanha>
{
    private RadarContexto contexto;
    public CampanhaRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<Campanha>> TodosAsync()
    {
        return await contexto.Campanhas.ToListAsync();
    }

    public async Task IncluirAsync(Campanha campanha)
    {
        contexto.Campanhas.Add(campanha);
        await contexto.SaveChangesAsync();
    }

    public async Task<Campanha> AtualizarAsync(Campanha campanha)
    {
        contexto.Entry(campanha).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return campanha;
    }

    public async Task ApagarAsync(Campanha campanha)
    {
        var obj = await contexto.Campanhas.FindAsync(campanha.Id);
        if(obj is null) throw new Exception("Campanha não encontrada");
        contexto.Campanhas.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
