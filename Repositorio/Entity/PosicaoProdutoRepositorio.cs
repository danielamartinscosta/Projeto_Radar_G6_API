using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class PosicaoProdutoRepositorio : IServico<PosicaoProduto>
{
    private RadarContexto contexto;
    public PosicaoProdutoRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<PosicaoProduto>> TodosAsync()
    {
        return await contexto.PosicoesProdutos.ToListAsync();
    }

    public async Task IncluirAsync(PosicaoProduto posicaoProduto)
    {
        contexto.PosicoesProdutos.Add(posicaoProduto);
        await contexto.SaveChangesAsync();
    }

    public async Task<PosicaoProduto> AtualizarAsync(PosicaoProduto posicaoProduto)
    {
        contexto.Entry(posicaoProduto).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return posicaoProduto;
    }

    public async Task ApagarAsync(PosicaoProduto posicaoProduto)
    {
        var obj = await contexto.PosicoesProdutos.FindAsync(posicaoProduto.Id);
        if(obj is null) throw new Exception("PosicaoProduto não encontrado");
        contexto.PosicoesProdutos.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
