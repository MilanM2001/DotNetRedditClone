namespace DotNet_RedditClone.Service.RuleService
{
    public interface IRuleService
    {
        Task<List<Rule>> GetAll();

        Task<Rule> GetSingle(int ruleId);

        Task<Rule> AddRule(Rule newruleId);

        Task<Rule> UpdateRule(Rule updateruleId);

        Task<Rule> DeleteRule(int ruleIdId);
    }
}
