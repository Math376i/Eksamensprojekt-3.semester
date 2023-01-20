namespace Application.DTOs.User;

public class LoginAndRegisterDTO
{
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string? Role { get; set; }
    
}