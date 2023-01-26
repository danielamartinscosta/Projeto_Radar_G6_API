using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Column("Descricao")]
        public string Descricao { get; set; } = default!;

        [Column("Valor")]
        public double Valor { get; set; } = default!;

        [Column("QuantidadeEstoque")]
        public int QuantidadeEstoque { get; set; } = default!;

        [Column("Foto")]
        public string? Foto { get; set; }


    }



}