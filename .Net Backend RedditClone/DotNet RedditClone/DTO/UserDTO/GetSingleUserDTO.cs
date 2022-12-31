using DotNet_RedditClone.Model.Enum;

namespace DotNet_RedditClone.DTO.UserDTO;

public class GetSingleUserDTO
{
    public int UserId { get; set; }
        
    public string Username { get; set; } = string.Empty;

    public string Avatar { get; set; }
        
    public string Email { get; set; }
        
    public DateTime DateOfRegistration { get; set; }
        
    public string Description { get; set; }
        
    public string DisplayName { get; set; }
}