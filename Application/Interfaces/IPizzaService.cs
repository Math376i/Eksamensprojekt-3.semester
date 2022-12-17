
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaService
{
    public void RebuildDB();

    public List<Pizza> GetAllPizzas();

    Pizza CreateNewPizza(PizzaDTOs dto);
    public Pizza DeletePizza(int Id);
    
    public Pizza UpdatePizza(int pizzaId, PizzaUpdateDTOs dto);
    List<Pizza> getPizzaFromOrder(object orderId);
}