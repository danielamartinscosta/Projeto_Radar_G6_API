using RadarWebApi.Models;

namespace RadarWebApi.DTOs
{

    public record PedidoProdutoDTO
    {

        public string PedidoId { get; set; } = default!;
        public Pedido? Pedido { get; set; }

        public string ProdutoId { get; set; } = default!;
        public Produto? Produto { get; set; }

        public double Valor { get; set; } = default!;

        public int Quantidade { get; set; } = default!;


    }



}


