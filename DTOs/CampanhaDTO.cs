
namespace RadarWebApi.DTOs
{
    public record CampanhaDTO
    {

        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public DateTime Data { get; set; } = default!;
        public string? Foto { get; set; } 


    }



}