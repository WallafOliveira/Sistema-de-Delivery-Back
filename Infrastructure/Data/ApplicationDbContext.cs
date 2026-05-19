using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_back.Domain.Entities;

namespace Sistema_de_delivery_back.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Restaurante> Restaurantes { get; set; }
    public DbSet<Produto> Produtos { get; set; }

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


        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Valor).IsRequired().HasPrecision(18, 2);

            // Relacionamento: Um Produto pertence a um Restaurante
            entity.HasOne(e => e.Restaurante)
                  .WithMany() // Se o Restaurante não tem uma lista de produtos na entidade dele, deixamos vazio
                  .HasForeignKey(e => e.RestauranteId)
                  .OnDelete(DeleteBehavior.Restrict); // Evita deletar um restaurante e apagar os produtos em cascata sem querer
        });


    }
}
