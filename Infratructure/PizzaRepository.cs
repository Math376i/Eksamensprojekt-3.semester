using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure;

public class PizzaRepository : IPizzaRepository
{
   
    private PizzaDbContext _pizzaContext;

    public PizzaRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }
    public void RebuildDB()
    {
        _pizzaContext.Database.EnsureDeleted();
        _pizzaContext.Database.EnsureCreated();
    }

    public List<Pizza> GetAllPizzas()
    {
        return _pizzaContext.PizzaTable.ToList();
    }

    public Pizza CreateNewPizza(Pizza pizza)
    {
        _pizzaContext.PizzaTable.Add(pizza);
        _pizzaContext.SaveChanges();
        return pizza;
    }
}