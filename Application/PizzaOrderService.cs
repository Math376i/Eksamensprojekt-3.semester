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
    
    public List<PizzaOrder> GetPizzaOrders()
    {
        return _pizzaOrderRepository.GetPizzaOrders();
    }

    public BuyPizza CreatePizzaOrder(BuyPizza buyPizza)
    {
        return _pizzaOrderRepository.CreatePizzaOrder(buyPizza);
    }

    public PizzaOrder DeletePizzaOrder(int id)
    {
        return _pizzaOrderRepository.DeletePizzaOrder(id);
    }

    public void DeletePizzaFromOrder(int i)
    {
        throw new NotImplementedException();
    }

    public List<PizzaOrder> GetPizzaFromOrder()
    {
        throw new NotImplementedException();
    }

 
}