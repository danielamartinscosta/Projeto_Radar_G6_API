using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Pedidos")]
    public class Pedido
    {


        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("ClietneId")]
        public string CLienteId { get; set; } = default!;
        public Cliente? Cliente { get; set; }

        [Column("ValorTotal")]
        public double ValorTotal { get; set; } = default!;

        [Column("DataPedido")]
        public DateTime DataPedido { get; set; } = default!;


    }



}