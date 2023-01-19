using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class PedidoProdutoRepositorio : IServico<PedidoProduto>
{
    private RadarContexto contexto;
    public PedidoProdutoRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<PedidoProduto>> TodosAsync()
    {
        return await contexto.PedidoProdutos.ToListAsync();
    }

    public async Task IncluirAsync(PedidoProduto pedidoProduto)
    {
        contexto.PedidoProdutos.Add(pedidoProduto);
        await contexto.SaveChangesAsync();
    }

    public async Task<PedidoProduto> AtualizarAsync(PedidoProduto pedidoProduto)
    {
        contexto.Entry(pedidoProduto).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return pedidoProduto;
    }

    public async Task ApagarAsync(PedidoProduto pedidoProduto)
    {
        var obj = await contexto.PedidoProdutos.FindAsync(pedidoProduto.Id);
        if(obj is null) throw new Exception("PedidoProduto não encontrado");
        contexto.PedidoProdutos.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
