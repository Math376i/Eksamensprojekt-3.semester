using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class PizzaOrderRepository : IPizzaOrderRepository
{
    private PizzaDbContext _pizzaContext;

    public PizzaOrderRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }

    public Pizza PizzaToOrder(Pizza pizza)
    {
        _pizzaContext.PizzaOrderTable.Add(pizza);
        _pizzaContext.SaveChanges();
        return PizzaToOrder(pizza);
    }

    public List<Pizza> GetPizzaFromOrder()
    {
        return _pizzaContext.PizzaOrderTable.ToList();
    }

    public Pizza DeletePizzaFromOrder(int id)
    {
        var pizzaToDelete = _pizzaContext.PizzaOrderTable.Find(id) ?? throw new KeyNotFoundException();
        _pizzaContext.PizzaOrderTable.Remove(pizzaToDelete);
        _pizzaContext.SaveChanges();
        return pizzaToDelete;
    }
}