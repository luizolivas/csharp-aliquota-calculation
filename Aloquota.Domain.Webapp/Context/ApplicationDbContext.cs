using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Webapp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutoFinanceiro { get; set; }
        public DbSet<HistoricoMovimentacao> HistoricoMovimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoMovimentacao>()
                .HasOne(h => h.ProdutoFinanceiro)
                .WithMany(p => p.HistoricoMovimentacoes)
                .HasForeignKey(h => h.ProdutoFinanceiroId);

            modelBuilder.Entity<ProdutoFinanceiro>()
                .Property(p => p.Valor)
                .HasPrecision(18, 2);

            modelBuilder.Entity<HistoricoMovimentacao>()
                .Property(h => h.Valor)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProdutoFinanceiro>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.ProdutoFinanceiros)
                .HasForeignKey(p => p.ClienteId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
