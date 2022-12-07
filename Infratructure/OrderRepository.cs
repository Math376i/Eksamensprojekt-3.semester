using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private PizzaDbContext _pizzaContext;


    public OrderRepository()
    {
        
    }
    
    
    public List<Order> GetAllOrders()
    {
        return _pizzaContext.OrderTable.ToList();
    }

    public Order CreateNewOrder(Order order)
    {
        _pizzaContext.OrderTable.Add(order);
        _pizzaContext.SaveChanges();
        return order;
    }

    public Order DeleteOrder(int orderId)
    {
        var orderToDelete = _pizzaContext.OrderTable.Find(orderId) ?? throw new KeyNotFoundException();
        _pizzaContext.OrderTable.Remove(orderToDelete);
        _pizzaContext.SaveChanges();
        return orderToDelete;
    }
    
}