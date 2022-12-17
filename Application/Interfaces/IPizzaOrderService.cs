using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderService
{
    public List<PizzaOrder> GetPizzaOrders();

    public BuyPizza CreatePizzaOrder(BuyPizza buyPizza);
    
    public PizzaOrder DeletePizzaOrder(int orderId);

    List<PizzaOrder> GetPizzaFromOrder();
    void DeletePizza(int i);
}