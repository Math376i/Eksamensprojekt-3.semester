using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

public class PizzaDbContext : DbContext
{
    
    public PizzaDbContext(DbContextOptions<PizzaDbContext> opts) : base(opts)
    {
        
    }
    // This Class helps to make the database and all the keys in the database

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
            .HasOne(p =>p.pizza)
            .WithMany(p => p.PizzasOnOrders);
        

        modelBuilder.Entity<PizzaOrder>()
            .HasMany<Pizza>(p => p.Pizzas)
            .WithOne(l => l.PizzaOrder);

        modelBuilder.Entity<PizzaOrder>()
            .HasMany<Order>(p => p.Orders)
            .WithOne(l => l.PizzaOrder);
                
        modelBuilder.Entity<PizzaOrder>()
            .Ignore(p => p.pizza);
        modelBuilder.Entity<PizzaOrder>()
            .Ignore(p => p.order);
        
    }

    public DbSet<PizzaOrder> JoinedTable { get; set; }

    public DbSet<Pizza> PizzaTable { get; set; }

    public DbSet<Order> OrderTable { get; set; }
}