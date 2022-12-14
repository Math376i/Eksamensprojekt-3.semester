using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaRepository
{
    public void RebuildDB();
    List<Pizza> GetPizzaFromOrder(int orderId);
    
    Pizza CreateNewPizza(Pizza pizza);
    
    public Pizza DeletePizza(int id);
    Pizza UpdatePizza(Pizza pizza);
}