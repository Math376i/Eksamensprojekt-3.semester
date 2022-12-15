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

    public List<Pizza> GetPizzaFromOrder(int orderId)
    {
        return _pizzaContext.PizzaTable.Where(x => x.OrderId == orderId).ToList();
    }

    public Pizza CreateNewPizza(Pizza pizza)
    {
        _pizzaContext.PizzaTable.Add(pizza);
        _pizzaContext.SaveChanges();
        return pizza;
    }

  public Pizza DeletePizza(int id)
        {
            var pizzaToDelete = _pizzaContext.PizzaTable.Find(id) ?? throw new KeyNotFoundException();
            _pizzaContext.PizzaTable.Remove(pizzaToDelete);
            _pizzaContext.SaveChanges();
            return pizzaToDelete;
        }
  public Pizza UpdatePizza(Pizza pizza)
  {
      _pizzaContext.PizzaTable.Update(pizza);
      _pizzaContext.SaveChanges();
      return pizza;
  }
  
}
