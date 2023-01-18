using Microsoft.EntityFrameworkCore;
using RadarWebApi.Models;

namespace RadarG6.Context;

public class RadarContexto : DbContext

{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_RADAR_G6");
        if (conexao is null) conexao = "server=localhost;database=radar_g6;uid=root;pwd=2411dmcroot*";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }
    
    
    //public RadarContexto(DbContextOptions<RadarContexto> options) : base(options) { }


    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Campanha> Campanhas { get; set; } = default!;
    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Loja> Lojas { get; set; } = default!;
    public DbSet<Pedido> Pedidos { get; set; } = default!;
    public DbSet<PedidoProduto> PedidoProdutos { get; set; } = default!;
    public DbSet<PosicaoProduto> PosicoesProdutos { get; set; } = default!;
    public DbSet<Produto> Produtos { get; set; } = default!;

}