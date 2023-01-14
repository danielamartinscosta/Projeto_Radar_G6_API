using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Campanha")]
    public class Campanha
    {

        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Display(Name = "Descriçao")]
        [Column("Descricao")]
        public string Descricao { get; set; } = default!;

        [Display(Name = "Data")]
        [Column("Data")]
        public DateTime Data { get; set; } = default!;

        [Display(Name = "Foto")]
        [Column("Foto")]
        public string? Foto { get; set; } // verificar esse item


    }



}