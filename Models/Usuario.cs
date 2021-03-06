using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projeto_jobs_net.Models
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

    [Column("nascimento", TypeName = "date")]
    [Required]
    public DateTime Nascimento { get;set; }

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


    [Column("estadoCivil", TypeName = "varchar")]
    [MaxLength(150)]
    public string EstadoCivil { get;set; }

    [Column("possuiVeiculo", TypeName = "varchar")]
    public string PossuiVeiculo { get;set; }

    [Column("possuiHabilitacao", TypeName = "varchar")]
    public string PossuiHabilitacao { get;set; }

    [Column("dado_id")]
    [Required]
    [ForeignKey("DadoId")]
    public int DadoId { get; set; }

    [ForeignKey("EnderecoId")]
    public int EnderecoId { get; set; }
    
    [JsonIgnore]
    public Dado Dado { get; set; }
    
           
  }
}