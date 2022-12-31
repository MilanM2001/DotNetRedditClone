namespace DotNet_RedditClone.Service.UserService;

public interface IUserService
{
    Task<List<User>> GetAll();

    Task<User> GetSingle(int userId);

    public string GetMyUsername();

    public string GetMyRole();

    public int LoggedUserId();
    
    Task<User> FindFirstByUsername(string username);

    Task<User> RegisterUser(User newUser);
}