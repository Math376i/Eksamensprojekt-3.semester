using Domain;

namespace Application.DTOs;

public class PizzaDTOs
{

    public string Name { get; set; }

    public Price price { get; set; }
    
    public string Topping { get; set; }
}