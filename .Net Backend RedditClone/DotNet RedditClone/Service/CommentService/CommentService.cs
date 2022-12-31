namespace DotNet_RedditClone.Service.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetSingle(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<Comment> AddComment(Comment newComment)
        {
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
            return newComment;
        }

        public async Task<Comment> UpdateComment(Comment updateComment)
        {
            await _context.SaveChangesAsync();
            return updateComment;
        }

        public async Task<Comment> DeleteComment(int commentId)
        {
            Comment comment = await _context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                throw new Exception("Comment not found.");
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
