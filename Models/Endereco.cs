using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Endereco")]
    public class Endereco
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "CEP")]
        [Column("CEP")]
        public string CEP { get; set; } = default!;

        [Display(Name = "Logradouro")]
        [Column("Logradouro")]
        public string Logradouro { get; set; } = default!;

        [Display(Name = "Numero")]
        [Column("Numero")]
        public string Numero { get; set; } = default!;

        [Display(Name = "Complemento")]
        [Column("Complemento")]
        public string Complemento { get; set; } = default!;

        [Display(Name = "Bairro")]
        [Column("Bairro")]
        public string Bairro { get; set; } = default!;

        [Display(Name = "Cidade")]
        [Column("Cidade")]
        public string Cidade { get; set; } = default!;

        [Display(Name = "Estado")]
        [Column("Estado")]
        public string Estado { get; set; } = default!;

        [Display(Name = "Latitude")]
        [Column("Latitude")]
        public string? Latitude { get; set; }


        [Display(Name = "Longitude")]
        [Column("Longitude")]
        public string? Longitude { get; set; }


    }



}