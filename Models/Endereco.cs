using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace jobs_net.Models
{
  [Table("enderecos")]
  public class Endereco
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    //APRESENTANDO ERRO QUANTO A STRING NO CEP: Coluna, parâmetro ou variável #2: não é possível encontrar o tipo de dados string.

    [Column("cep", TypeName = "varchar")]
    [Required]
    [MaxLength(9)]
    public string Cep { get;set; }

    [Column("logradouro", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Logradouro { get;set; }

    [Column("numero", TypeName = "int")]
    [Required]
    public int Numero { get;set; }


    [Column("bairro", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Bairro { get;set; }

    [Column("cidade", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Cidade { get;set; }

    [Column("estado", TypeName = "varchar")]
    [Required]
    [MaxLength(2)]
    public string Estado { get;set; }

    [Column("pais", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Pais { get;set; }

    [Column("usuario_id")]
    [Required]
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    [JsonIgnore]
    public Usuario Usuario { get; set; }
}
}