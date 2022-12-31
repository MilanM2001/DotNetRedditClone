using DotNet_RedditClone.DTO.CommentDTO;
using DotNet_RedditClone.Service.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<Comment>>> GetAll()
        {
            List<Comment> comments = await _commentService.GetAll();
            List<GetAllCommentDTO> commentsDTO = _mapper.Map<List<Comment>, List<GetAllCommentDTO>>(comments);

            return Ok(commentsDTO);
        }

        [HttpPut]
        [Route("Update/{commentId}")]
        public async Task<ActionResult<Comment>> UpdateComment(UpdateCommentDTO updateCommentDTO, [FromRoute] int commentId)
        {
            Comment comment = await _commentService.GetSingle(commentId);

            if (comment == null)
            {
                return NotFound("Could not find a Comment with ID: " + commentId);
            }

            comment.Text = updateCommentDTO.Text;

            await _commentService.UpdateComment(comment);

            return Ok(updateCommentDTO);
        }

        [HttpDelete]
        [Route("{commentId}")]
        public async Task<ActionResult<Comment>> DeleteComment([FromRoute] int commentId)
        {
            Comment comment = await _commentService.GetSingle(commentId);

            if (comment == null)
            {
                return NotFound("Could not find a Comment with ID: " + commentId);
            }

            await _commentService.DeleteComment(commentId);
            return Ok();
        }

    }
}
