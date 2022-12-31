namespace DotNet_RedditClone.Service.CommunityService
{
    public interface ICommunityService
    {
        Task<List<Community>> GetAll();

        Task<Community> GetSingle(int communityId);

        Task<Community> FindFirstByName(string name);

        Task<List<Post>> GetCommunityPosts(int communityId);

        Task<List<Flair>> GetCommunityFlairs(int communityId);

        Task<List<Rule>> GetCommunityRules(int communityId);

        Task<Community> AddCommunity(Community newCommunity);

        Task<Community> UpdateCommunity(Community updateCommunity);

        Task<Community> DeleteCommunity(int communityId);
    }
}
