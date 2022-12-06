﻿using System.ComponentModel.DataAnnotations;
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
    public void RebuildDB()
    {
        _orderRepository.RebuildDB();
    }
    
    public List<Order> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }

    public Order CreateNewOrder(OrderDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _orderRepository.CreateNewOrder(_mapper.Map<Order>(dto));
    }

    public Order DeleteOrder(int orderId)
    {
        return _orderRepository.DeleteOrder(orderId);
    }
}