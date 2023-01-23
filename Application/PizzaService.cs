using AutoMapper;
using FluentValidation;
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

    public PizzaService(IPizzaRepository mockRepositoryObject, IMapper mapper, PostPizzaValidator postValidator, PizzaValidator pizzaValidator)
    {
        _pizzaRepository = mockRepositoryObject ?? throw new ArgumentNullException();
        
    }

    public PizzaService(IMapper repositoryObject, IPizzaRepository mockRepositoryObject)
    {
        _pizzaRepository = mockRepositoryObject ?? throw new ArgumentNullException();

    }

 


    // This method helps to rebuild the database
    public void RebuildDB()
    {
        _pizzaRepository.RebuildDB();
    }
// This method helps to get a list of all the pizzas
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaRepository.GetAllPizzas();
    }
// This method helps to create a new pizza
    public Pizza CreateNewPizza(PizzaDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _pizzaRepository.CreateNewPizza(_mapper.Map<Pizza>(dto));

    }

    // This method helps to delete a pizza
    public Pizza DeletePizza(int orderId)
    {

        return _pizzaRepository.DeletePizza(orderId);
    }
// This method helps to update a pizza
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