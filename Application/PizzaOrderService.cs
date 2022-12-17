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
    public BuyPizza CreatePizzaOrder(BuyPizza buyPizza)
    {
        return _pizzaOrderRepository.CreatePizzaOrder(buyPizza);
    }

    // This method helps to delete a pizza from a order
    public PizzaOrder DeletePizzaOrder(int id)
    {
        return _pizzaOrderRepository.DeletePizzaOrder(id);
    }
    

    public List<PizzaOrder> GetPizzaFromOrder()
    {
        throw new NotImplementedException();
    }

 
}