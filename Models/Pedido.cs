using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Pedidos")]
    public class Pedido
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Cliente")]
        [Column("ClietneId")]
        public string CLienteId { get; set; } = default!;
        public Cliente? Cliente { get; set; }

        [Display(Name = "Valor Total")]
        [Column("ValorTotal")]
        public double ValorTotal { get; set; } = default!;

        [Display(Name = "Data do Pedido")]
        [Column("DataPedido")]
        public DateTime DataPedido { get; set; } = default!;


    }



}