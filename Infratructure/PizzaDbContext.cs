using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace Infrastructure;

public class PizzaDbContext : DbContext
{
    
    public PizzaDbContext(DbContextOptions<PizzaDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Pizza>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Order>()
            .Property(o => o.OrderId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Pizza>()
              .HasOne<Order>()
              .WithMany()
              .HasForeignKey(o => o.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

    }
    
    public DbSet<Pizza> PizzaTable { get; set; }

    public DbSet<Order> OrderTable { get; set; }
}