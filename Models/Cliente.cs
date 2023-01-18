using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RadarWebApi.Models
{
    [Table("Clientes")]
    public class Cliente
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Column("CPF")]
        public string Cpf { get; set; } = default!;

        [Column("Email")]
        public string Email { get; set; } = default!;

        [Column("Telefone")]
        public string? Telefone { get; set; }

        [Column("CEP")]
        public string CEP { get; set; } = default!;

        [Column("Logradouro")]
        public string Logradouro { get; set; } = default!;

        [Column("Numero")]
        public string Numero { get; set; } = default!;


        [Column("Complemento")]
        public string Complemento { get; set; } = default!;


        [Column("Bairro")]
        public string Bairro { get; set; } = default!;


        [Column("Cidade")]
        public string Cidade { get; set; } = default!;


        [Column("Estado")]
        public string Estado { get; set; } = default!;




    }


}


