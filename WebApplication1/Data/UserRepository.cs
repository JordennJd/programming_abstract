using WebApplication1.Models;
namespace WebApplication1.Data;

public class UserRepository : IUserRepository
{
    private IUserRepository _userRepositoryImplementation;
    
    private UserContext _context;
    
    public UserRepository(UserContext context)
    {
        _context = context;
    }

    public User Create(User user)
    {
        _context.Users.Add(user);

        user.id = _context.SaveChanges();
        return user;
        
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.email == email);
    }
    
    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.id == id);
    }
}