using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IPizzaOrderService
{
    public Pizza PizzaToOrder(PizzaDTOs dto);
    
    List<Pizza> GetPizzaFromOrder();

    public Pizza DeletePizzaFromOrder(int id);
}