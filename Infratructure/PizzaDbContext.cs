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
        
        modelBuilder.Entity<PizzaOrder>()
            .HasKey(a => new { a.PizzaId, a.OrderId });

        modelBuilder.Entity<Order>()
            .HasMany<PizzaOrder>(o => o.PizzaOrders)
            .WithOne(p => p.order)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pizza>()
            .HasOne<PizzaOrder>(p => p.PizzaOrders)
            .WithMany( p => p.pizza)
            .HasForeignKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PizzaOrder>()
            .HasMany<Pizza>(p => p.pizza)
            .WithOne(l => l.PizzaOrders);
        
        modelBuilder.Entity<PizzaOrder>()
            .HasOne<Order>(p => p.order)
            .WithMany(l => l.PizzaOrders);
        
        modelBuilder.Entity<PizzaOrder>()
              .Ignore(p => p.pizza);
          modelBuilder.Entity<PizzaOrder>()
              .Ignore(p => p.order);
          modelBuilder.Entity<Pizza>()
              .Ignore(p => p.PizzaOrders);
          modelBuilder.Entity<Order>()
              .Ignore(p => p.PizzaOrders);
    }
    
    public DbSet<Pizza> PizzaTable { get; set; }

    public DbSet<Pizza> PizzaOrderTable { get; set; }

    public DbSet<Order> OrderTable { get; set; }
}