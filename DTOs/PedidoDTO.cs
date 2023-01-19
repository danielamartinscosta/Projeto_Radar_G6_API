using RadarWebApi.Models;

namespace RadarWebApi.DTOs
{
    public record PedidoDTO
    {

        public string CLienteId { get; set; } = default!;
        public Cliente? Cliente { get; set; }
        public double ValorTotal { get; set; } = default!;
        public DateTime DataPedido { get; set; } = default!;


    }



}