using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure;

public class PizzaRepository : IPizzaRepository
{
    public List<Pizza> GetAll()
    {
        throw new NotImplementedException();
    }

    public ActionResult CreateNewPizza(Pizza dto)
    {
        throw new NotImplementedException();
    }
}