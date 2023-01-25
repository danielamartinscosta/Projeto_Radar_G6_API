using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RadarWebApi.Models
{
    [Table("Lojas")]
    public class Loja
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Column("Observacao")]
        public string? Observacao { get; set; }

        [Column("CEP")]
        public string CEP { get; set; } = default!;

        [Column("Logradouro")]
        public string Logradouro { get; set; } = default!;

        [Column("Numero")]
        public string Numero { get; set; } = default!;

        [Column("Complemento")]
        public string? Complemento { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; } = default!;

        [Column("Cidade")]
        public string Cidade { get; set; } = default!;

        [Column("Estado")]
        public string Estado { get; set; } = default!;

        [Column("Latitude")]
        public string Latitude { get; set; } = default!;

        [Column("Longitude")]
        public string Longitude { get; set; } = default!;

    }


}