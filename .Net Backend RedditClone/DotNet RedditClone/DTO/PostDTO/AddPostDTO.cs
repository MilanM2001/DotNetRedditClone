namespace DotNet_RedditClone.DTO.PostDTO
{
    public class AddPostDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int FlairId { get; set; }
    }
}
