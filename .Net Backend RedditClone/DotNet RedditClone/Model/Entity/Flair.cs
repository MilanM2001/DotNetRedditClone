using System.Text.Json.Serialization;

namespace DotNet_RedditClone.Model.Entity
{
    [Table("Flair")]
    public class Flair
    {
        [Key]
        public int FlairId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("CommunityId")]
        public int CommunityId { get; set; }
        public Community Community { get; set; } = new Community();  

        public HashSet<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
