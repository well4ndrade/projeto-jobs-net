using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projeto_jobs_net.Models
{
  [Table("curriculos")]
  public class Curriculo
  {

    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "text")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }

    [Column("cargo", TypeName = "text")]
    [MaxLength(150)]
    [Required]
    public string Cargo { get;set; }
    
    [Column("sobre", TypeName = "text")]
    [MaxLength(150)]
    [Required]
    public string Sobre { get;set; }

    [Column("escolaridade", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Escolaridade { get;set; }
  }
}