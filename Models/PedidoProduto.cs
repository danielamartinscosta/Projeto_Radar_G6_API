using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("PedidoProdutos")]
    public class PedidoProduto
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Pedido")]
        public int PedidoId { get; set; } = default!;
        public Pedido? Pedido { get; set; }

        [Column("Produto")]
        public int ProdutoId { get; set; } = default!;
        public Produto? Produto { get; set; }


        [Column("Valor")]
        public double Valor { get; set; } = default!;

        [Column("Quantidade")]
        public int Quantidade { get; set; } = default!;


    }



}


