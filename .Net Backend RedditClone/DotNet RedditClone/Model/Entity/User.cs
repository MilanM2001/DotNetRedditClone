using DotNet_RedditClone.Model.Enum;
using Google.Protobuf.WellKnownTypes;

namespace DotNet_RedditClone.Model.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        public string Avatar { get; set; }
        
        public string Email { get; set; }
        
        public DateTime DateOfRegistration { get; set; }
        
        public string Description { get; set; }
        
        public string DisplayName { get; set; }
        
        public ERole Role { get; set; }
    }
}
