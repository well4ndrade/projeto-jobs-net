using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobs_net.Models
{
  [Table("vagas")]
  public class Vaga
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }

    [Column("descricao", TypeName = "text")]
    [Required]    
    public string descricao { get;set; }
  }
}