using RadarWebApi.Models;
namespace RadarWebApi.DTOs
{
    public record PosicaoProdutoDTO
    {

        public string CampanhaId { get; set; } = default!;
        public Campanha? Campanha { get; set; }
        public string PosicaoX { get; set; } = default!;
        public string PosicaoY { get; set; } = default!;
        

    }



}