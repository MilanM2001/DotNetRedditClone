namespace DotNet_RedditClone.Service.PostService
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();

        Task<Post> GetSingle(int postId);

        Task<List<Comment>> GetPostComments(int postId);

        Task<Post> AddPost(Post newPost);

        Task<Post> UpdatePost(Post updatePost);

        Task<Post> DeletePost(int postId);
    }

}
