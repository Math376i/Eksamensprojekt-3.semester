using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrasturkture;

public class PizzaDbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Pizza>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Box> BoxTable { get; set; }
}