namespace DotNet_RedditClone.Model.Entity
{
    [Table("Community")]
    public class Community
    {
        [Key]
        public int CommunityId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Timestamp]
        public DateTime CreatedDate { get; set; }

        public bool IsSuspended { get; set; }

        public string SuspendedReason { get; set; } = string.Empty;

        public HashSet<Post> Posts { get; set; } = new HashSet<Post>();

        public HashSet<Rule> Rules { get; set; } = new HashSet<Rule>();

        public HashSet<Flair> Flairs { get; set; } = new HashSet<Flair>();
    }
}
