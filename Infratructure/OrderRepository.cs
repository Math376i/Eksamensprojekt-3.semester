using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private PizzaDbContext _pizzaContext;
    
    public OrderRepository(PizzaDbContext context)
    {
        _pizzaContext = context;
    }
    // This method helps to get a list of all orders in the program
    public List<Order> GetAllOrders()
    {
        return _pizzaContext.OrderTable.ToList();
    }
// This method helps to create a new order in the program
    public Order CreateNewOrder(Order order)
    {
        _pizzaContext.OrderTable.Add(order);
        _pizzaContext.SaveChanges();
        return order;
    }
// This method helps to delete a order in the program
    public Order DeleteOrder(int orderId)
    {
        var orderToDelete = _pizzaContext.OrderTable.Find(orderId) ?? throw new KeyNotFoundException();
        _pizzaContext.OrderTable.Remove(orderToDelete);
        _pizzaContext.SaveChanges();
        return orderToDelete;
    }

  
    

}