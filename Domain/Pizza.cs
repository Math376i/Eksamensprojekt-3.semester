namespace Domain;

public class Pizza
{

    public int Id { get; set; }
    
    public string Name { get; set; }

    public Price price { get; set; }

    public string Topping { get; set; }
    public PizzaOrder? PizzaOrders { get; set; }

}