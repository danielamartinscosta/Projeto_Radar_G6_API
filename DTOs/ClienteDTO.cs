
namespace RadarWebApi.DTOs
{
    public record ClienteDTO
    {

        public string Nome { get; set; } = default!;

        public string Cpf { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string? Telefone { get; set; }

        public string CEP { get; set; } = default!;

        public string Logradouro { get; set; } = default!;

        public string Numero { get; set; } = default!;

        public string Complemento { get; set; } = default!;

        public string Bairro { get; set; } = default!;

        public string Cidade { get; set; } = default!;

        public string Estado { get; set; } = default!;




    }


}


