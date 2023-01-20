using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class UserRepository: IUserRepository
{
    private readonly PizzaDbContext _context;
    
    public UserRepository(PizzaDbContext context)
    {
        _context = context;
    }

    public User GetUserByEmail(string Email)
    {
        return _context.UserTable.FirstOrDefault(u => u.Email == Email) ??
               throw new KeyNotFoundException("There was no user with email" + Email);
    }

    public User CreateNewUser(User user)
    {
        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }
}