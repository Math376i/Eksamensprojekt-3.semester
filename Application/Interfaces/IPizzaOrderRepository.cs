using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderRepository
{
    public List<Pizza> PizzaToOrder(Pizza pizza);
}