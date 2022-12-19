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

 
   // This method helps to get a pizzaOrder in the program
   public List<PizzaOrder> GetPizzaOrders()
   {
       throw new NotImplementedException();
   }
// This method helps to create a new PizzaOrder in the program
   public PizzaOrder CreatePizzaOrder(PizzaOrder pizzaOrder)
    {
        _pizzaContext.JoinedTable.Add(pizzaOrder);
        _pizzaContext.SaveChanges();
        return CreatePizzaOrder(pizzaOrder);
    }

   
   
// This method helps to delete a PizzaOrder in the program
   public PizzaOrder DeletePizzaOrder(int orderId)
    {
        var pizzaOrderToDelete = _pizzaContext.JoinedTable.Find(orderId) ?? throw new KeyNotFoundException();
        _pizzaContext.JoinedTable.Remove(pizzaOrderToDelete);
        _pizzaContext.SaveChanges();
        return pizzaOrderToDelete;
    }
}