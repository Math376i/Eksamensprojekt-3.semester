using Application;
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
    private IOrderService _orderService;
    private IPizzaOrderService _pizzaOrderService;

    public PizzaController(IPizzaService service, IOrderService orderService, IPizzaOrderService pizzaOrderService)
    {
        _pizzaService = service;
        _orderService = orderService;
        _pizzaOrderService = pizzaOrderService;
    }
    
    [HttpGet]
    [Route("RebuildDb")]
    public string RebuildDb()
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

    [HttpGet]
    [Route("GetAllOrders")]
    public List<Order> GetAllOrders()
    {
        return _orderService.GetAllOrders();
    }

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

    [HttpGet]
    [Route("GetPizzaOrder")]
    public List<PizzaOrder> GetPizzaOrders()
    {
        return _pizzaOrderService.GetPizzaOrders();
    }

    [HttpPost]
    [Route("CreatePizzaOrder")]
    public ActionResult CreateNewPizzaOrder(BuyPizza buyPizza)
    {
        try
        {
            return Ok(_pizzaOrderService.CreatePizzaOrder(buyPizza));
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

    [HttpDelete]
    [Route("DeletePizzaOrder")]
    public ActionResult<PizzaOrder> DeletePizzaOrder(int orderId)
    {
        try
        {
            return Ok(_pizzaOrderService.DeletePizzaOrder(orderId));
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No pizzaOrder found at orderId" + orderId);
        }
    }

}