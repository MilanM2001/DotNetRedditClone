using DotNet_RedditClone.DTO.RuleDTO;
using DotNet_RedditClone.Service.RuleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        private readonly IRuleService _ruleService;
        private readonly IMapper _mapper;

        public RuleController(IRuleService ruleService, IMapper mapper)
        {
            _ruleService = ruleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Single/{ruleId}")]
        public async Task<ActionResult<Rule>> GetSingle([FromRoute] int ruleId)
        {
            Rule rule = await _ruleService.GetSingle(ruleId);
            GetAllRuleDTO ruleDTO = _mapper.Map<Rule, GetAllRuleDTO>(rule);

            if (rule == null)
            {
                return NotFound("Could not find a Rule with ID: " + ruleId);
            }

            return Ok(ruleDTO);
        }

        [HttpPut]
        [Route("Update/{ruleId}")]
        [Authorize]
        public async Task<ActionResult<Rule>> UpdateRule(UpdateRuleDTO updateRuleDTO, [FromRoute] int ruleId)
        {
            Rule rule = await _ruleService.GetSingle(ruleId);

            if (rule == null)
            {
                return NotFound("Could not find a Rule with ID: " + ruleId);
            }

            rule.Name = updateRuleDTO.Name;
            rule.Description = updateRuleDTO.Description;

            await _ruleService.UpdateRule(rule);

            return Ok(updateRuleDTO);
        }

        [HttpDelete]
        [Route("{ruleId}")]
        [Authorize]
        public async Task<ActionResult<Rule>> DeleteRule([FromRoute] int ruleId)
        {
            Rule rule = await _ruleService.GetSingle(ruleId);

            if (rule == null)
            {
                return NotFound("Could not find a Rule with ID: " + ruleId);
            }

            await _ruleService.DeleteRule(ruleId);
            return Ok();
        }
    }
}
