using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaRepository
{
    //This interface helps to get all the methods into the classes there are using it
    public void RebuildDB();

    public List<Pizza> GetAllPizzas();
    
    Pizza CreateNewPizza(Pizza pizza);
    
    public Pizza DeletePizza(int id);
    Pizza UpdatePizza(Pizza pizza);
    
}