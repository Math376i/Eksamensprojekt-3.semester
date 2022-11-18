

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application;  

public class PizzaService : IPizzaService
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private IValidator<PizzaDTOs> _postValidator;
    private IValidator<Pizza> _pizzaValidator;
    
    public PizzaService(IPizzaRepository repository, IMapper mapper, IValidator<PizzaDTOs> postValidator, IValidator<Pizza> pizzaValidator)
    {
        _pizzaRepository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _pizzaValidator = pizzaValidator;
    }
    
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaRepository.GetAll();
    }

    public ActionResult CreateNewPizza(PizzaDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());


        return _pizzaRepository.CreateNewPizza(_mapper.Map<Pizza>(dto));
    }

    
}