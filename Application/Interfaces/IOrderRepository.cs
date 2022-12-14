using Domain;

namespace Application.Interfaces;

public interface IOrderRepository
{
    
    List<Order> GetAllOrders();

    Order CreateNewOrder(Order order);
    Order DeleteOrder(int orderId);

    public Order GetOrderIdByEmail(string email);
}