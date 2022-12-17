namespace Domain;

public class BuyPizza
{
    //This Class helps to get all the values of a pizza when a customer buy's it
    public int Id { get; set; }
    
    public string CustomerName { get; set; }

    public int PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public Pizza[] pizzasOrdered { get; set; }
}