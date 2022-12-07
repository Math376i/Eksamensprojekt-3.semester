using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Domain;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }

    public int PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public Pizza OrderPizza { get; set; }

    public int PizzaId { get; set; }

    public PizzaOrder PizzaOrder { get; set; }

    public ICollection<Pizza> Pizzas { get; set; }

}  