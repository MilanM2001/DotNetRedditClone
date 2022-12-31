using DotNet_RedditClone.DTO.RuleDTO;

namespace DotNet_RedditClone.DTO.CommunityDTO;

public class AddCommunityRulesDTO
{
    public HashSet<GetAllRuleDTO> Rules { get; set; } = new HashSet<GetAllRuleDTO>();
}