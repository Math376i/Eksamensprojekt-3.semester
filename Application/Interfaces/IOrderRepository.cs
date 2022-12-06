using Domain;

namespace Application.Interfaces;

public interface IOrderRepository
{
    public void RebuildDB();
    List<Order> GetAllOrders();

    Order CreateNewOrder(Order order);
    Order DeleteOrder(int orderId);
}