namespace Domain;

public class PizzaOrder
{
    public int PizzaId { get; set; }
    
    public int OrderId { get; set; }

    public Order order { get; set; }

    public List<Pizza> pizza { get; set; }
}