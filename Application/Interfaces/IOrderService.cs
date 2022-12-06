using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IOrderService
{
    public void RebuildDB();
    List<Order> GetAllOrders();

    Order CreateNewOrder(OrderDTOs dto);

    Order DeleteOrder(int orderId);
}