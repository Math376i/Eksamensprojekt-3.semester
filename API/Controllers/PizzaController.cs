
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    [Route("Rebuilddb")]
    [HttpGet]
    public void rebuild()
    {
        
    }
}