using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;

namespace Application;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;
    private PostOrderValidator _postValidator;
    private OrderValidator _orderValidator;
    private IMapper _mapper;

    public OrderService(IOrderRepository repository, PostOrderValidator postValidator,OrderValidator orderValidator,IMapper mapper)
    {
        _orderRepository = repository;
        _postValidator = postValidator;
        _orderValidator = orderValidator;
        _mapper = mapper;

    }
    
    // This method helps to get all the orders
    public List<Order> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }
// This method helps to create a new order
    public Order CreateNewOrder(OrderDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _orderRepository.CreateNewOrder(_mapper.Map<Order>(dto));
    }
// This method helps to delete a order
    public Order DeleteOrder(int orderId)
    {
        return _orderRepository.DeleteOrder(orderId);
    }

    
}