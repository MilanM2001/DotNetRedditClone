namespace DotNet_RedditClone.Service.CommentService
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAll();

        Task<Comment> GetSingle(int commentId);

        Task<Comment> AddComment(Comment newComment);

        Task<Comment> UpdateComment(Comment updateComment);

        Task<Comment> DeleteComment(int commentId);
    }
}
