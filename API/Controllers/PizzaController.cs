using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
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
    
    [HttpGet]
    [Route("GetAllPizzas")]
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaService.GetAllPizzas();
    }
    
    [HttpPost]
    [Route("CreatePizza")]
    public ActionResult CreateNewBox(PizzaDTOs dto)
    {
        try
        {
            var result = _pizzaService.CreateNewPizza(dto);
            return Created("pizza/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPut]
    public ActionResult<Pizza> UpdatePizza([FromBody] Pizza pizza)
    {
        try
        {
            return Ok(_pizzaService.Updatepizza(pizza.Id ,pizza));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID " + pizza.Id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Pizza> DeletePizza(int id)
    {
        try
        {
            return Ok(_pizzaService.DeletePizza(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No pizza found at ID " + id);
        }
    }
    
}