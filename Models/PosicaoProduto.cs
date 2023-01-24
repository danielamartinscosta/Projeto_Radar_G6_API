using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("PosicoesProdutos")]
    public class PosicaoProduto
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Campanha")]
        public int CampanhaId { get; set; } = default!;
        public Campanha? Campanha { get; set; }

        [Column("PosicaoX")]
        public string PosicaoX { get; set; } = default!;

        [Column("PosicaoY")]
        public string PosicaoY { get; set; } = default!;
        

    }



}