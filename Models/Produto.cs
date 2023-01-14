using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Display(Name = "Descrição")]
        [Column("Descricao")]
        public string Descricao { get; set; } = default!;

        [Display(Name = "Valor")]
        [Column("Valor")]
        public double Valor { get; set; } = default!;

        [Display(Name = "Estoque")]
        [Column("QuantidadeEstoque")]
        public int QuantidadeEstoque { get; set; } = default!;


    }



}