using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Domain;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }

    public int PhoneNumber { get; set; }
    
    public string Email { get; set; }

}  