
using Application.Interfaces;
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
    [Route("RebuildDB")]
    public string RebuildDB()
    {
        _pizzaService.RebuildDB();
        return "Db has been created";
    }
}