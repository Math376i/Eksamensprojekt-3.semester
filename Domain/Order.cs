

namespace Domain;

public class Order
{
    //This Class helps to get all the values of a order
    public int OrderId { get; set; }
    

    public int Password { get; set; }
    
    public string Email { get; set; }
    
    public int PizzaId { get; set; }

    public Pizza pizza { get; set; }
    
    public List<Pizza> PizzasOrderList { get; set; }
    
    

}  