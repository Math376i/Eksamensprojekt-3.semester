namespace Domain;

public class Pizza
{
    public const bool IsValid = true;

    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Price { get; set; }
    
    public string Topping { get; set; }
    
    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenPrice { get; set; }

}