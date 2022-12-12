using Application.DTOs;
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

    public Pizza PizzaToOrder(PizzaDTOs dto)
    {
        return _repository.PizzaToOrder(_mapper.Map<Pizza>(dto));
    }

    public List<Pizza> GetPizzaFromOrder()
    {
        return _repository.GetPizzaFromOrder();
    }

    public Pizza DeletePizzaFromOrder(int id)
    {
        return _repository.DeletePizzaFromOrder(id);
    }
}