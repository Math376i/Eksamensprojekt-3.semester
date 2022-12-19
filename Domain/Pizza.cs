using System.Net.Mail;

namespace Domain;

public class Pizza
{
   
    
    //This Class helps to get all the values of a pizza 

    public int Id { get; set; }
    
    public string Name { get; set; }

    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenfriPrice { get; set; }

    public string Topping { get; set; }

    public List<Order> PizzasOnOrders { get; set; }
    
    
    
   
    
    
}