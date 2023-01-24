using RadarWebApi.Models;

namespace RadarWebApi.DTOs
{

    public record PedidoProdutoDTO
    {

        public int PedidoId { get; set; } = default!;
        
        public int ProdutoId { get; set; } = default!;

        public double Valor { get; set; } = default!;

        public int Quantidade { get; set; } = default!;


    }



}


