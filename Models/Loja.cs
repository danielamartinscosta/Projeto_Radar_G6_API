using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Loja")]
    public class Loja
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Display(Name = "Observaçao")]
        [Column("Observacao")]
        public string? Observacao { get; set; }

        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string EnderecoId { get; set; } = default!;

        public Endereco? Endereco { get; set; }


    }



}