using System.Security.Claims;

namespace DotNet_RedditClone.Service.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetSingle(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public string GetMyUsername()
    {
        string result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        return result;
    }
    
    public string GetMyRole()
    {
        string result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role.ToString());
        }

        return result;
    }

    public int LoggedUserId()
    {
        var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        return userId;
    }
    
    public async Task<User> FindFirstByUsername(string username)
    {
        return await _context.Users.Where(user => user.Username == username).FirstOrDefaultAsync();
    }

    public async Task<User> RegisterUser(User newUser)
    {
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }
}