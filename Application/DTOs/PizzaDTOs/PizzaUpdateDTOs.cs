using Domain;

namespace Application.DTOs;

public class PizzaUpdateDTOs
{
    // This Class helps to get and set the values  to a pizza so it could update
    public int Id { get; set; }
    
    public string Name { get; set; }

    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenfriPrice { get; set; }

    public string Topping { get; set; }
}