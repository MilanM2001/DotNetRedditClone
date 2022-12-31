using DotNet_RedditClone.DTO.CommentDTO;
using DotNet_RedditClone.Service.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, ICommentService commentService, IMapper mapper)
        {
            _postService = postService;
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            List<Post> posts = await _postService.GetAll();
            List<GetAllPostDTO> postsDTO = _mapper.Map<List<Post>, List<GetAllPostDTO>>(posts);

            return Ok(postsDTO);
        }

        [HttpGet]
        [Route("Single/{postId}")]
        public async Task<ActionResult<Post>> GetSingle([FromRoute] int postId)
        {
            Post post = await _postService.GetSingle(postId);
            GetSinglePostDTO postDTO = _mapper.Map<Post, GetSinglePostDTO>(post);

            if (post == null)
            {
                return NotFound("Could not find a Post with ID: " + postId);
            }

            return Ok(postDTO);
        }

        [HttpGet]
        [Route("Comments/{postId}")]
        public async Task<ActionResult<List<Comment>>> GetPostComments([FromRoute] int postId)
        {
            Post post = await _postService.GetSingle(postId);

            if (post == null)
            {
                return NotFound("Could not find a Post with ID: " + postId);
            }

            List<Comment> comments = await _postService.GetPostComments(postId);
            List<GetAllCommentDTO> commentsDTO = _mapper.Map<List<Comment>, List<GetAllCommentDTO>>(comments);

            return Ok(commentsDTO);
        }

        [HttpPost]
        [Route("AddComment/{postId}")]
        [Authorize]
        public async Task<ActionResult<Comment>> AddComment(AddCommentDTO addCommentDTO, [FromRoute] int postId)
        {
            Post post = await _postService.GetSingle(postId);

            if (post == null)
            {
                return NotFound("Could not find a Post with ID: " + postId);
            }

            Comment newComment = new Comment();

            newComment.Text = addCommentDTO.Text;
            newComment.CreatedDate = DateTime.UtcNow;
            newComment.IsDeleted = false;
            newComment.Post = post;

            await _commentService.AddComment(newComment);

            return Ok(addCommentDTO);
        }

        [HttpPut]
        [Route("Update/{postId}")]
        [Authorize]
        public async Task<ActionResult<Post>> UpdatePost(UpdatePostDTO updatePostDTO, [FromRoute] int postId)
        {
            Post post = await _postService.GetSingle(postId);

            if (post == null)
            {
                return NotFound("Could not find a Post with ID: " + postId);
            }

            post.Title = updatePostDTO.Title;
            post.Text = updatePostDTO.Text;
            
            await _postService.UpdatePost(post);

            return Ok(updatePostDTO);
        }

        [HttpDelete]
        [Route("{postId}")]
        [Authorize]
        public async Task<ActionResult<Post>> DeletePost([FromRoute] int postId)
        {
            Post post = await _postService.GetSingle(postId);

            if (post == null)
            {
                return NotFound("Could not find a Post with ID: " + postId);
            }

            await _postService.DeletePost(postId);
            return Ok();
        }
    }
}
