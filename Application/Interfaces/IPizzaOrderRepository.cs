using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderRepository
{
    public Pizza PizzaToOrder(Pizza pizza);

    List<Pizza> GetPizzaFromOrder();
    
    public Pizza DeletePizzaFromOrder(int id);



}