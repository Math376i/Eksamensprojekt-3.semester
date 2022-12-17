using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IOrderService
{
    //This interface helps to get all the methods into the classes there are using it
    List<Order> GetAllOrders();

    Order CreateNewOrder(OrderDTOs dto);

    Order DeleteOrder(int orderId);
    
}