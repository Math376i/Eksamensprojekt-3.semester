namespace Domain;

public class PizzaOrder
{
    //This Class helps to get all the values of a pizza on a order
    public int PizzaId { get; set; }

    public int OrderId { get; set; }
    
    public List<Pizza> Pizzas { get; set; }
    
    public List<Order> Orders { get; set; }

    public Order order { get; set; }
    
    public List<Pizza> pizza { get; set; }
    public string PizzaName { get; set; }
}