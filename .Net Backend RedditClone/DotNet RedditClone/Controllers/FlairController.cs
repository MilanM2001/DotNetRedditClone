using DotNet_RedditClone.DTO.FlairDTO;
using DotNet_RedditClone.Service.FlairService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlairController : ControllerBase
    {
        private readonly IFlairService _flairService;
        private readonly IMapper _mapper;

        public FlairController(IFlairService flairService, IMapper mapper)
        {
            _flairService = flairService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<Flair>>> GetAll()
        {
            List<Flair> flairs = await _flairService.GetAll();
            List<GetAllFlairDTO> flairsDTO = _mapper.Map<List<Flair>, List<GetAllFlairDTO>>(flairs);

            return Ok(flairsDTO);
        }
    }
}
