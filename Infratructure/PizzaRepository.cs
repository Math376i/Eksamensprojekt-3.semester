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
    public List<Pizza> GetAll()
    {
        throw new NotImplementedException();
    }

    public ActionResult CreateNewPizza(Pizza dto)
    {
        throw new NotImplementedException();
    }
}