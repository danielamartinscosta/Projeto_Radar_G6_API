using RadarWebApi.Models;

namespace RadarWebApi.DTOs
{
    public record PedidoDTO
    {

        public int ClienteId { get; set; } = default!;
        public double ValorTotal { get; set; } = default!;
        public DateTime DataPedido { get; set; } = default!;


    }



}