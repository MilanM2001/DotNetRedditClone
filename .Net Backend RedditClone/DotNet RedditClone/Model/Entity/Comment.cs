namespace DotNet_RedditClone.Model.Entity
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        [Timestamp]
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; } = new Post();
    }
}
