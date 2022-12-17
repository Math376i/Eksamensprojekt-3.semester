using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using Domain;

namespace Application;

public class PizzaService : IPizzaService
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private PostPizzaValidator _postValidator;
    private PizzaValidator _pizzaValidator;
    private IOrderService _orderService;

    public PizzaService(IPizzaRepository repository, IMapper mapper, PostPizzaValidator postValidator,
        PizzaValidator pizzaValidator, IOrderService orderService)
    {
        _pizzaRepository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _pizzaValidator = pizzaValidator;
        _orderService = orderService;
    }

    public void RebuildDB()
    {
        _pizzaRepository.RebuildDB();
    }

    public List<Pizza> GetAllPizzas()
    {
        return _pizzaRepository.GetAllPizzas();
    }

    public Pizza CreateNewPizza(PizzaDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _pizzaRepository.CreateNewPizza(_mapper.Map<Pizza>(dto));

    }

    public Pizza DeletePizza(int orderId)
    {

        return _pizzaRepository.DeletePizza(orderId);
    }

    public Pizza UpdatePizza(int pizzaId, PizzaUpdateDTOs dto)
    {
        if (pizzaId != dto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _pizzaValidator.Validate(_mapper.Map<Pizza>(dto));
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _pizzaRepository.UpdatePizza(_mapper.Map<Pizza>(dto));

    }
}