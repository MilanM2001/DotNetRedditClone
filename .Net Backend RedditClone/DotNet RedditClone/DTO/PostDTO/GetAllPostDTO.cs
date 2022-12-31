using DotNet_RedditClone.DTO.CommunityDTO;
using DotNet_RedditClone.DTO.FlairDTO;

namespace DotNet_RedditClone.DTO.PostDTO
{
    public class GetAllPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public SimpleCommunityDTO Community { get; set; }
        public GetAllFlairDTO Flair { get; set; }
    }
}
