namespace Domain;

public class PizzaOrder
{
    public int Id { get; set; }
    
    public int PizzaId { get; set; }
    
    public int OrderId { get; set; }

    public Order order { get; set; }

    public Pizza pizza { get; set; }
}