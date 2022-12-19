
using Application.DTOs;
using Domain;


namespace Application.Interfaces;

public interface IPizzaService
{
    //This interface helps to get all the methods into the classes there are using it
    public void RebuildDB();

    public List<Pizza> GetAllPizzas();

    Pizza CreateNewPizza(PizzaDTOs dto);
    public Pizza DeletePizza(int Id);
    
    public Pizza UpdatePizza(int pizzaId, PizzaUpdateDTOs dto);
 
}