namespace DotNet_RedditClone.Model.Entity
{
    [Table("Rule")]
    public class Rule
    {
        [Key]
        public int RuleId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("CommunityId")]
        public int CommunityId { get; set; }
        public Community Community { get; set; } = new Community();
    }
}
