namespace DotNet_RedditClone.Service.RuleService
{
    public class RuleService : IRuleService
    {
        private readonly DataContext _context;

        public RuleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Rule>> GetAll()
        {
            return await _context.Rules.ToListAsync();
        }

        public async Task<Rule> GetSingle(int ruleId)
        {
            return await _context.Rules.FindAsync(ruleId);
        }

        public async Task<Rule> AddRule(Rule newRule)
        {
            _context.Rules.Add(newRule);
            await _context.SaveChangesAsync();
            return newRule;
        }

        public async Task<Rule> UpdateRule(Rule updateRule)
        {
            await _context.SaveChangesAsync();
            return updateRule;
        }

        public async Task<Rule> DeleteRule(int ruleId)
        {
            Rule rule = await _context.Rules.FindAsync(ruleId);

            if (rule == null)
            {
                throw new Exception("Community not found.");
            }

            _context.Rules.Remove(rule);
            await _context.SaveChangesAsync();
            return rule;
        }
    }
}
