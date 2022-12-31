using DotNet_RedditClone.DTO.FlairDTO;

namespace DotNet_RedditClone.DTO.CommunityDTO
{
    public class GetAllCommunityDTO
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isSuspended { get; set; }
        public string SuspendedReason { get; set; }
    }
}
