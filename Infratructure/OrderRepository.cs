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

    public Order GetOrderIdByEmail(string email)
    {
        Order order = _pizzaContext.OrderTable.Where(o => o.Email == email).ToList().FirstOrDefault();
        if (order != null)
        {
            return order;
        }
        else
        {
            throw new Exception("Could not find order");
        }
    }
    
    

}