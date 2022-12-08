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

    public PizzaService(IPizzaRepository repository, IMapper mapper, PostPizzaValidator postValidator,
        PizzaValidator pizzaValidator)
    {
        _pizzaRepository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _pizzaValidator = pizzaValidator;
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

    public Pizza DeletePizza(int id)
    {

        return _pizzaRepository.DeletePizza(id);
    }

    public Pizza Updatepizza(int pizzaId, PizzaUpdateDTOs dto)
    {
        if (pizzaId != dto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _pizzaValidator.Validate(_mapper.Map<Pizza>(dto));
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _pizzaRepository.UpdatePizza(_mapper.Map<Pizza>(dto));

    }
}