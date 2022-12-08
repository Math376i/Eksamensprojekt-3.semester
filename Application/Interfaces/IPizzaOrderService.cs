using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderService
{
    public List<Pizza> PizzaToOrder(Pizza pizza);
}