using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("PosicoesProdutos")]
    public class PosicoesProdutos
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Campanha")]
        [Column("Campanha")]
        public string CampanhaId { get; set; } = default!;
        public Campanha? Campanha { get; set; }

        [Display(Name = "PosicaoX")]
        [Column("PosicaoX")]
        public string PosicaoX { get; set; } = default!;


        [Display(Name = "PosicaoY")]
        [Column("PosicaoY")]
        public string PosicaoY { get; set; } = default!;
        

    }



}