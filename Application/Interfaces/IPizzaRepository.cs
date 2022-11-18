using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IPizzaRepository
{
    List<Pizza> GetAll();
    
    ActionResult CreateNewPizza(Pizza dto);
}