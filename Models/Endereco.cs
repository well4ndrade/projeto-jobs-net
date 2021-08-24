using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projeto_jobs_net.Models
{
  [Table("enderecos")]
  public class Endereco
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

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

    [Column("usuario_id")]
    [Required]
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    [JsonIgnore]
    public Usuario Usuario { get; set; }
    

}
}