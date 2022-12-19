using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Application;

public class PizzaOrderService  : IPizzaOrderService
{
    private IPizzaOrderRepository _pizzaOrderRepository;

    public PizzaOrderService(IMapper mapper, IPizzaOrderRepository repository)
    {
        _pizzaOrderRepository = repository;
    }
    // This method helps to get a pizza order
    public List<PizzaOrder> GetPizzaOrders()
    {
        return _pizzaOrderRepository.GetPizzaOrders();
    }
// This method helps to create a pizza order
    public PizzaOrder CreatePizzaOrder(PizzaOrder pizzaOrder)
    {
        return _pizzaOrderRepository.CreatePizzaOrder(pizzaOrder);
    }

    // This method helps to delete a pizza from a order
    public PizzaOrder DeletePizzaOrder(int id)
    {
        return _pizzaOrderRepository.DeletePizzaOrder(id);
    }
    

  

 
}