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
        
        modelBuilder.Entity<Order>()
            .HasOne(p =>p.pizza)
            .WithMany(p => p.PizzasOnOrders);
        
        modelBuilder.Entity<Order>()
            .HasIndex(o => o.Email)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(u => u.UserId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }

    

    public DbSet<Pizza> PizzaTable { get; set; }
    public DbSet<Order> OrderTable { get; set; }
    public DbSet<User> UserTable { get; set; }
    
}