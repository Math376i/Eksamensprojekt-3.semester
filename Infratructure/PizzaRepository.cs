
using Application.Interfaces;
using Domain;



namespace Infrastructure;

public class PizzaRepository : IPizzaRepository
{
   
    private PizzaDbContext _pizzaContext;

    public PizzaRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }
    // This method helps to rebuild the database
    public void RebuildDB()
    {
        _pizzaContext.Database.EnsureDeleted();
        _pizzaContext.Database.EnsureCreated();
    }
// This method helps to get all the pizzas from the database
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaContext.PizzaTable.ToList();
    }
// This method helps to create a new pizza in the database
    public Pizza CreateNewPizza(Pizza pizza)
    {
        _pizzaContext.PizzaTable.Add(pizza);
        _pizzaContext.SaveChanges();
        return pizza;
    }
// This method helps to delete a pizza from the database
  public Pizza DeletePizza(int id)
        {
            var pizzaToDelete = _pizzaContext.PizzaTable.Find(id) ?? throw new KeyNotFoundException();
            _pizzaContext.PizzaTable.Remove(pizzaToDelete);
            _pizzaContext.SaveChanges();
            return pizzaToDelete;
        }
  
  // This method helps to update a pizza in the database
  public Pizza UpdatePizza(Pizza pizza)
  {
      _pizzaContext.PizzaTable.Update(pizza);
      _pizzaContext.SaveChanges();
      return pizza;
  }
  
}
