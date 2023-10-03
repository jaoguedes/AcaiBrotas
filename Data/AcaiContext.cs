using AcaiBrotas.Models;
using Microsoft.EntityFrameworkCore;

namespace AcaiBrotas.Data
{
    public class AcaiContext : DbContext
    {
        public AcaiContext(DbContextOptions<AcaiContext> options) : base(options) { }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Tipo>().ToTable("Tipos");

        }
    }
}
