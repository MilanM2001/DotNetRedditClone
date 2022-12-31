namespace DotNet_RedditClone.Model.Entity
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; } =string.Empty;

        [Required]
        public string Text { get; set; } = string.Empty;

        [Timestamp]
        public DateTime CreatedDate { get; set; }


        [ForeignKey("CommunityId")]
        public int CommunityId { get; set; }
        public Community Community { get; set; } = new Community();
        
        
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        
        
        [ForeignKey("FlairId")]
        public int? FlairId { get; set; }
        public Flair? Flair { get; set; }
        

        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
