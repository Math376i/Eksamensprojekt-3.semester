using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Application;

public class PizzaOrderService : IPizzaOrderService
{
    private IMapper _mapper;
    private IPizzaOrderRepository _repository;
    public PizzaOrderService(IMapper mapper, IPizzaOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public List<Pizza> PizzaToOrder(Pizza pizza)
    {
        return _repository.PizzaToOrder(pizza);
    }
}