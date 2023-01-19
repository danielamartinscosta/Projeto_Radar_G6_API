
namespace RadarWebApi.DTOs
{
    public record LojaDTO
    {

        public string Nome { get; set; } = default!;

        public string? Observacao { get; set; }

        public string CEP { get; set; } = default!;

        public string Logradouro { get; set; } = default!;

        public string Numero { get; set; } = default!;

        public string Complemento { get; set; } = default!;

        public string Bairro { get; set; } = default!;

        public string Cidade { get; set; } = default!;

        public string Estado { get; set; } = default!;

        public string Latitude { get; set; } = default!;

        public string Longitude { get; set; } = default!;


    }



}