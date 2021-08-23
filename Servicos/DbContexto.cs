using projeto_jobs_net.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_jobs_net.Servicos
{
  public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Dado> Dados { get; set; }
    
  }
}