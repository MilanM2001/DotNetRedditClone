namespace DotNet_RedditClone.Service.CommunityService
{
    public class CommunityService : ICommunityService
    {
        private readonly DataContext _context;

        public CommunityService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Community>> GetAll()
        {
            return await _context.Communities.ToListAsync();
        }

        public async Task<Community> GetSingle(int communityId)
        {
            return await _context.Communities.FindAsync(communityId);
        }

        public async Task<Community> FindFirstByName(string name)
        {
            return await _context.Communities.Where(community => community.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetCommunityPosts(int communityId)
        {
            return await _context.Posts.
                Where(post => post.CommunityId == communityId).
                Include(post => post.Community).ToListAsync();
        }

        public async Task<List<Flair>> GetCommunityFlairs(int communityId)
        {
            return await _context.Flairs.
                Where(flair => flair.CommunityId == communityId).ToListAsync();
        }

        public async Task<List<Rule>> GetCommunityRules(int communityId)
        {
            return await _context.Rules.
                Where(rule => rule.CommunityId == communityId).ToListAsync();
        }

        public async Task<Community> AddCommunity(Community newCommunity)
        {
            _context.Communities.Add(newCommunity);
            await _context.SaveChangesAsync();
            return newCommunity;
        }

        public async Task<Community> UpdateCommunity(Community updateCommunity)
        {
            await _context.SaveChangesAsync();
            return updateCommunity;
        }

        public async Task<Community> DeleteCommunity(int communityId)
        {
            Community community = await _context.Communities.FindAsync(communityId);

            if (community == null)
            {
                throw new Exception("Community not found.");
            }

            _context.Communities.Remove(community);
            await _context.SaveChangesAsync();
            return community;
        }
    }
}
