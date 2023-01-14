using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("PedidoProduto")]
    public class PedidoProduto
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Pedido")]
        [Column("Pedido")]
        public string PedidoId { get; set; } = default!;
        public Pedido? Pedido { get; set; }

        [Display(Name = "Produto")]
        [Column("Produto")]
        public string ProdutoId { get; set; } = default!;
        public Produto? Produto { get; set; }

        [Display(Name = "Valor")]
        [Column("Valor")]
        public double Valor { get; set; } = default!;

        [Display(Name = "Quantidade")]
        [Column("Quantidade")]
        public int Quantidade { get; set; } = default!;


    }



}


