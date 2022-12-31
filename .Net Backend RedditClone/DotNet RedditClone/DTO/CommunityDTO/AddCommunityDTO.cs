using DotNet_RedditClone.DTO.FlairDTO;
using DotNet_RedditClone.DTO.RuleDTO;

namespace DotNet_RedditClone.DTO.CommunityDTO
{
    public class AddCommunityDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public HashSet<GetAllRuleDTO> Rules { get; set; } = new HashSet<GetAllRuleDTO>();

    }
}
