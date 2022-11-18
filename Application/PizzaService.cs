using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class PizzaService : IPizzaService
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private IValidator<PizzaDTOs> _postValidator;
    private IValidator<Pizza> _pizzaValidator;
    public PizzaService(IPizzaRepository repository
        /*IMapper mapper,
        IValidator<PizzaDTOs> postValidator,
        IValidator<Pizza> boxValidator*/
        )
    {
        _pizzaRepository = repository;
        /*_mapper = mapper;
        _postValidator = postValidator;
        _pizzaValidator = boxValidator;*/
    }
    
    public void RebuildDB()
    {
        _pizzaRepository.RebuildDB();
    }
}