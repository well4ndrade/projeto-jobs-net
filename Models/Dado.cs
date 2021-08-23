using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_jobs_net.Models
{
  [Table("dados")]
  public class Dado
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("login", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Login { get;set; }

    [Column("passwd", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Passwd { get;set; }


  }
}