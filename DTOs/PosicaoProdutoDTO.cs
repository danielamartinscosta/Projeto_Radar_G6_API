using RadarWebApi.Models;
namespace RadarWebApi.DTOs
{
    public record PosicaoProdutoDTO
    {

        public int CampanhaId { get; set; } = default!;
        public string PosicaoX { get; set; } = default!;
        public string PosicaoY { get; set; } = default!;
        

    }



}