using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Domain;

public class Order
{
    //This Class helps to get all the values of a order
    public int OrderId { get; set; }
    public string CustomerName { get; set; }

    public int PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public int PizzaId { get; set; }

    public Pizza pizza { get; set; }
    
    public List<Pizza> PizzasOrderList { get; set; }
    
    

}  