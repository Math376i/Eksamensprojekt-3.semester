namespace Domain;

public class BuyPizza
{
    public int Id { get; set; }
    
    public string CustomerName { get; set; }

    public int PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public Pizza[] pizzasOrdered { get; set; }
}