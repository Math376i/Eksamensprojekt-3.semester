using System.Net.Mail;

namespace Domain;

public class Pizza
{
    

    public int Id { get; set; }
    
    public string Name { get; set; }

    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenfriPrice { get; set; }

    public string Topping { get; set; }

    public List<Order> PizzasOnOrders { get; set; }
    
    public PizzaOrder? PizzaOrder { get; set; }
    
    //public List<PizzaOrder> PizzaOrders { get; set; }*/
    
    
}