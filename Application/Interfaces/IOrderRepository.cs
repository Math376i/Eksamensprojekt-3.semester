using Domain;

namespace Application.Interfaces;

public interface IOrderRepository
{
    //This interface helps to get all the methods into the classes there are using it
    List<Order> GetAllOrders();

    Order CreateNewOrder(Order order);
    Order DeleteOrder(int orderId);
    
}