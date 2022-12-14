
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaService
{
    public void RebuildDB();
    List<Pizza> getPizzaFromOrder(string email);

    Pizza CreateNewPizza(PizzaDTOs dto);
    public Pizza DeletePizza(int Id);
    
    public Pizza UpdatePizza(int pizzaId, PizzaUpdateDTOs dto);
}