using Domain;

namespace Application.DTOs;

public class PizzaUpdateDTOs
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public Price price { get; set; }

    public string Topping { get; set; }
}