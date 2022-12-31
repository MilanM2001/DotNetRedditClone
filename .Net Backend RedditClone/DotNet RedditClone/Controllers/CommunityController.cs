using DotNet_RedditClone.DTO.CommunityDTO;
using DotNet_RedditClone.DTO.FlairDTO;
using DotNet_RedditClone.DTO.RuleDTO;
using DotNet_RedditClone.Service.FlairService;
using DotNet_RedditClone.Service.RuleService;
using DotNet_RedditClone.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommunityService _communityService;
        private readonly IFlairService _flairService;
        private readonly IUserService _userService;
        private readonly IRuleService _ruleService;
        private readonly IMapper _mapper;

        public CommunityController(ICommunityService communityService, IPostService postService, IFlairService flairService, IUserService userService, IRuleService ruleService, IMapper mapper)
        {
            _postService = postService;
            _communityService = communityService;
            _flairService = flairService;
            _userService = userService;
            _ruleService = ruleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<Community>>> GetAll()
        {
            List<Community> communities = await _communityService.GetAll();
            List<GetAllCommunityDTO> communitiesDTO = _mapper.Map<List<Community>, List<GetAllCommunityDTO>>(communities);

            return Ok(communitiesDTO);
        }

        [HttpGet]
        [Route("Single/{communityId}")]
        public async Task<ActionResult<Community>> GetSingle([FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);
            GetSingleCommunityDTO communityDTO = _mapper.Map<Community, GetSingleCommunityDTO>(community);

            if (communityDTO == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            return Ok(communityDTO);
        }

        [HttpGet]
        [Route("Posts/{communityId}")]
        public async Task<ActionResult<List<Post>>> GetCommunityPosts([FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            List<Post> posts = await _communityService.GetCommunityPosts(communityId);
            List<GetAllPostDTO> postsDTO = _mapper.Map<List<Post>, List<GetAllPostDTO>>(posts);

            return Ok(postsDTO);
        }

        [HttpGet]
        [Route("Flairs/{communityId}")]
        public async Task<ActionResult<List<Flair>>> GetCommunityFlairs([FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            List<Flair> flairs = await _communityService.GetCommunityFlairs(communityId);
            List<GetAllFlairDTO> flairsDTO = _mapper.Map<List<Flair>, List<GetAllFlairDTO>>(flairs);

            return Ok(flairsDTO);
        }

        [HttpGet]
        [Route("Rules/{communityId}")]
        public async Task<ActionResult<List<Rule>>> GetCommunityRules([FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            List<Rule> rules = await _communityService.GetCommunityRules(communityId);
            List<GetAllRuleDTO> rulesDTO = _mapper.Map<List<Rule>, List<GetAllRuleDTO>>(rules);

            return Ok(rulesDTO);
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public async Task<ActionResult<Community>> AddCommunity(AddCommunityDTO addCommunityDTO)
        {
            Community foundCommunity = await _communityService.FindFirstByName(addCommunityDTO.Name);

            if (foundCommunity != null)
            {
                return StatusCode(406);
            }

            Community newCommunity = new Community();

            newCommunity.Name = addCommunityDTO.Name;
            newCommunity.Description = addCommunityDTO.Description;
            newCommunity.CreatedDate = DateTime.UtcNow;
            newCommunity.IsSuspended = false;
            newCommunity.SuspendedReason = "Not Suspended";

            await _communityService.AddCommunity(newCommunity);

            foreach (GetAllRuleDTO ruleDTO in addCommunityDTO.Rules)
            {
                Rule newRule = new Rule();

                newRule.Name = ruleDTO.Name;
                newRule.Description = ruleDTO.Description;
                newRule.Community = newCommunity;
                newCommunity.Rules.Add(newRule);

                await _ruleService.AddRule(newRule);
            }

            return Ok(addCommunityDTO);
        }

        [HttpPost]
        [Route("AddPost/{communityId}")]
        [Authorize]
        public async Task<ActionResult<Post>> AddPost(AddPostDTO addPostDTO, [FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);
            int userId = _userService.LoggedUserId();

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            Post newPost = new()
            {
                Title = addPostDTO.Title,
                Text = addPostDTO.Text,
                CreatedDate = DateTime.UtcNow,
                Community = community,
                User = await _userService.GetSingle(userId),
                Flair = await _flairService.GetSingle(addPostDTO.FlairId)
            };

            await _postService.AddPost(newPost);

            return Ok(addPostDTO);
        }

        [HttpPut]
        [Route("AddRule/{communityId}")]
        [Authorize]
        public async Task<ActionResult<Community>> AddRuleToCommunity(AddCommunityRulesDTO addCommunityRulesDTO, [FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }
            
            foreach (GetAllRuleDTO ruleDTO in addCommunityRulesDTO.Rules)
            {
                Rule newRule = new Rule();

                newRule.Name = ruleDTO.Name;
                newRule.Description = ruleDTO.Description;
                newRule.Community = community;
                community.Rules.Add(newRule);

                await _ruleService.AddRule(newRule);
            }

            return Ok();
        }

        [HttpPut]
        [Route("Update/{communityId}")]
        [Authorize]
        public async Task<ActionResult<Community>> UpdateCommunity(UpdateCommunityDTO updateCommunityDTO, [FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            community.Description = updateCommunityDTO.Description;

            await _communityService.UpdateCommunity(community);

            return Ok(updateCommunityDTO);
        }

        [HttpPut]
        [Route("Suspend/{communityId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Community>> SuspendCommunity(SuspendCommunityDTO suspendCommunityDTO, [FromRoute] int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);
            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            community.SuspendedReason = suspendCommunityDTO.SuspendedReason;
            community.IsSuspended = true;

            await _communityService.UpdateCommunity(community);

            return Ok(suspendCommunityDTO);
        }

        [HttpDelete]
        [Route("{communityId}")]
        [Authorize]
        public async Task<ActionResult<Community>> DeleteCommunity(int communityId)
        {
            Community community = await _communityService.GetSingle(communityId);

            if (community == null)
            {
                return NotFound("Could not find a Community with ID: " + communityId);
            }

            await _communityService.DeleteCommunity(communityId);
            return Ok();
        }
    }
}
