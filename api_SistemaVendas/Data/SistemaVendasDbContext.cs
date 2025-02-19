using api_SistemaVendas.Models.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace api_SistemaVendas.Data
{
    public class SistemaVendasDbContext : DbContext
    {
        public SistemaVendasDbContext(DbContextOptions<SistemaVendasDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FuncionarioModel>()
                .HasKey(f => f.Id);
        }

        public DbSet<FuncionarioModel> Funcionario { get; set; }
    }
}
