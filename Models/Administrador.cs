using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Administradores")]
    public class Administrador
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        public string Nome { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Senha { get; set; } = default!;

        public string Permissao { get; set; } = default!;



    }



}