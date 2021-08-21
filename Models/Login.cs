using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_jobs_net.Models
{
  [Table("login")]
  public class Login
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("login", TypeName = "varchar")]
    [MaxLength(16)]
    [Required]
    public string usuario { get;set; }

    [Column("passwd", TypeName = "varchar")]
    [Required]
    [MaxLength(16)]  
    public string senha { get;set; }
  }
}