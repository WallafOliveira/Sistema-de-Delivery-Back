using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_back.Domain.Entities;

namespace Sistema_de_delivery_back.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Restaurante> Restaurantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CPNJ).IsRequired().HasMaxLength(18);
            entity.Property(e => e.Endereco).IsRequired().HasMaxLength(500);
            entity.Property(e => e.EstaAberto).IsRequired();
        });
    }
}
