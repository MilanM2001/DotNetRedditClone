using DotNet_RedditClone.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNet_RedditClone.Service.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.
                Include(post => post.Community).
                Include(post => post.Flair).
                ToListAsync();
        }

        public async Task<Post> GetSingle(int postId)
        {
            return await _context.Posts.
                Include(post => post.Community).
                Include(post => post.Flair).
                FirstOrDefaultAsync(post => post.PostId == postId);
        }

        public async Task<List<Comment>> GetPostComments(int postId)
        {
            return await _context.Comments.
                Where(comment => comment.PostId == postId).
                ToListAsync();
        }
        public async Task<Post> AddPost(Post newPost)
        {
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }

        public async Task<Post> UpdatePost(Post updatePost)
        {
            await _context.SaveChangesAsync();
            return updatePost;
        }

        public async Task<Post> DeletePost(int postId)
        {
            Post post = await _context.Posts.FindAsync(postId);

            if (post == null)
            {
                throw new Exception("Post not found.");
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
