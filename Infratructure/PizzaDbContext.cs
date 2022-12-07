using Domain;
using Microsoft.EntityFrameworkCore;

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

        modelBuilder.Entity<Order>()
            .HasOne(order => order.OrderPizza)
            .WithMany(pizza => pizza.Orders)
            .HasForeignKey(order => order.PizzaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne<PizzaOrder>(o => o.PizzaOrder)
            .WithOne(p => p.order)
            .HasForeignKey<PizzaOrder>(po => po.OrderId);

        modelBuilder.Entity<Pizza>()
            .HasOne<PizzaOrder>(p => p.PizzaOrder)
            .WithOne(l => l.pizza)
            .HasForeignKey<PizzaOrder>(po => po.PizzaId);
    }
    
    public DbSet<Pizza> PizzaTable { get; set; }

    public DbSet<PizzaOrder> PizzaOrderTable { get; set; }

    public DbSet<Order> OrderTable { get; set; }
}