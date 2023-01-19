using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class PedidoRepositorio : IServico<Pedido>
{
    private RadarContexto contexto;
    public PedidoRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<Pedido>> TodosAsync()
    {
        return await contexto.Pedidos.ToListAsync();
    }

    public async Task IncluirAsync(Pedido pedido)
    {
        contexto.Pedidos.Add(pedido);
        await contexto.SaveChangesAsync();
    }

    public async Task<Pedido> AtualizarAsync(Pedido pedido)
    {
        contexto.Entry(pedido).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return pedido;
    }

    public async Task ApagarAsync(Pedido pedido)
    {
        var obj = await contexto.Pedidos.FindAsync(pedido.Id);
        if(obj is null) throw new Exception("Pedido não encontrado");
        contexto.Pedidos.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
