using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobs_net.Models
{
  [Table("usuarios")]
  public class Usuario
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Nome { get;set; }
    
    [Column("cpf", TypeName = "varchar")]
    [Required]
    [MaxLength(15)]
    public string Cpf { get;set; }

    [Column("rg", TypeName = "varchar")]
    [Required]
    [MaxLength(15)]
    public string Rg { get;set; }

    [Column("genero", TypeName = "varchar")]
    [MaxLength(15)]
    public string Genero { get;set; }

    // PROBLEMAS AO TENTAR EXECUTAR MIGRAÇÃO: "The property 'Usuario.DataNascimento' could not be mapped because it is of type 'string', 
    // which is not a supported primitive type or a valid entity type." 

    //ANTES ESTAVA:

    // [Column("dataNascimento", TypeName = "datetime")]
    // [Required]
    // public string DataNascimento { get;set; }

    //ATULIZADO:

    // [Column("nascimento", TypeName = "date")]
    // [Required]
    // public string Nascimento { get;set; }

    [Column("telefone", TypeName = "varchar")]
    [MaxLength(15)]
    public string Telefone { get;set; }

    [Column("telefone2", TypeName = "varchar")]
    [MaxLength(15)]
    public string Telefone2 { get;set; }

    [Column("email", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Email { get;set; }

    [Column("profissao", TypeName = "varchar")]
    [MaxLength(150)]
    public string Profissao { get;set; }

    [Column("estadoCivil", TypeName = "varchar")]
    [MaxLength(150)]
    public string EstadoCivil { get;set; }

    // [Column("possuiVeiculo", TypeName = "boolean")]
    // public string PossuiVeiculo { get;set; }

    // [Column("possuiHabilitacao", TypeName = "boolean")]
    // public string PossuiHabilitacao { get;set; }
  }
}