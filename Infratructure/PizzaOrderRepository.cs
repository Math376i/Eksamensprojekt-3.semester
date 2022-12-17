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

   /* public List<PizzaOrder> GetPizzaOrders()
    {
        return _pizzaContext.JoinedTable.ToList();
    }
*/
   public List<PizzaOrder> GetPizzaOrders()
   {
       throw new NotImplementedException();
   }

   public BuyPizza CreatePizzaOrder(BuyPizza buyPizza)
    {
        _pizzaContext.JoinedTable.Add(buyPizza);
        _pizzaContext.SaveChanges();
        return CreatePizzaOrder(buyPizza);
    }

   public PizzaOrder DeletePizzaOrder(int orderId)
   {
       throw new NotImplementedException();
   }

   /* public PizzaOrder DeletePizzaOrder(int orderId)
    {
        var pizzaOrderToDelete = _pizzaContext.JoinedTable.Find(orderId) ?? throw new KeyNotFoundException();
        _pizzaContext.JoinedTable.Remove(pizzaOrderToDelete);
        _pizzaContext.SaveChanges();
        return pizzaOrderToDelete;
    }*/
}