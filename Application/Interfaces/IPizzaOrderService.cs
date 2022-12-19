using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderService
{
    //This interface helps to get all the methods into the classes there are using it
    public List<PizzaOrder> GetPizzaOrders();

    public PizzaOrder CreatePizzaOrder(PizzaOrder pizzaOrder);
    
    public PizzaOrder DeletePizzaOrder(int orderId);

    
    
}