using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderService
{
    //This interface helps to get all the methods into the classes there are using it
    public List<PizzaOrder> GetPizzaOrders();

    public BuyPizza CreatePizzaOrder(BuyPizza buyPizza);
    
    public PizzaOrder DeletePizzaOrder(int orderId);

    List<PizzaOrder> GetPizzaFromOrder();
    
}