
using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private IPizzaService _pizzaService;
    private IOrderService _orderService;
   
    public PizzaController(IPizzaService service, IOrderService orderService)
    {
        _pizzaService = service;
        _orderService = orderService;
        
    }
    // This method helps rebuilding the database
    [AllowAnonymous]
    [HttpGet]
    [Route("RebuildDb")]
    public string RebuildDb()
    {
        _pizzaService.RebuildDB();
        
        return "Db has been created";
    }
// This method helps to get all the pizzas on a list
    [HttpGet]
    [Route("GetAllPizzas")]
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaService.GetAllPizzas();
    }
    
// This method helps to create a pizza and chick if the pizza is okay for the program
    [AllowAnonymous]
    [HttpPost]
    [Route("CreatePizza")]
    public ActionResult CreateNewPizza(PizzaDTOs dto)
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
    //This Method helps to update a pizza in the program.
    [HttpPut]
    public ActionResult<Pizza> UpdatePizza([FromBody] PizzaUpdateDTOs dto)
    {
        try
        {
            return Ok(_pizzaService.UpdatePizza(dto.Id ,dto));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No box found at ID " + dto.Id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    // This method helps to delete a pizza form the list of pizzas
    [HttpDelete]
    [Route("DeletePizza{Id}")]
    public ActionResult<Pizza> DeletePizza(int Id)
    {
        try
        {
            return Ok(_pizzaService.DeletePizza(Id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No pizza found at ID " + Id);
        }
    }
// This method helps to get all the orders from the list 
    [HttpGet]
    [Route("GetAllOrders")]
    public List<Order> GetAllOrders()
    {
        return _orderService.GetAllOrders();
    }
// This method helps to create a order in the program
    [HttpPost]
    [Route("CreateOrder")]
    public ActionResult CreateNewOrder([FromBody] OrderDTOs dto)
    {
        try
        {
            var result = _orderService.CreateNewOrder(dto);
            return Created("order/" + result.OrderId, result);
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
    // This method helps to delete a order ind the program
    [HttpDelete]
    [Route("DeleteOrder{orderId}")]
    public ActionResult<Order> DeleteOrder(int orderId)
    {
        try
        {
            return Ok(_orderService.DeleteOrder(orderId));

        }
        catch (KeyNotFoundException)
        {
            return NotFound("No order found at id " + orderId);
        }
    }


}