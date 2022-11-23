
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaService
{
    public void RebuildDB();
    List<Pizza> GetAllPizzas();

    Pizza CreateNewPizza(PizzaDTOs dto);
}