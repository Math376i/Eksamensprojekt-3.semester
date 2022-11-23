
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private IPizzaService _pizzaService;

    public PizzaController(IPizzaService service)
    {
        _pizzaService = service;
    }
    
    [HttpGet]
    [Route("GetAllBoxes")]
    public List<Pizza> GetBox()
    {
        return _pizzaService.GetAllPizzas();
    }
    
    [HttpGet]
    [Route("RebuildDB")]
    public string RebuildDB()
    {
        _pizzaService.RebuildDB();
        return "Db has been created";
    }
}