using Microsoft.EntityFrameworkCore;
using RadarG6.Context;
using RadarG6.Repositorios.Interfaces;
using RadarWebApi.Models;

namespace Radar.Repositorios;

public class ProdutoRepositorio : IServico<Produto>
{
    private RadarContexto contexto;
    public ProdutoRepositorio()
    {
        contexto = new RadarContexto();
    }

    public async Task<List<Produto>> TodosAsync()
    {
        return await contexto.Produtos.ToListAsync();
    }

    public async Task IncluirAsync(Produto produto)
    {
        contexto.Produtos.Add(produto);
        await contexto.SaveChangesAsync();
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        contexto.Entry(produto).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return produto;
    }

    public async Task ApagarAsync(Produto produto)
    {
        var obj = await contexto.Produtos.FindAsync(produto.Id);
        if(obj is null) throw new Exception("Produto não encontrado");
        contexto.Produtos.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}
