using DotNet_RedditClone.DTO.CommentDTO;
using DotNet_RedditClone.DTO.CommunityDTO;
using DotNet_RedditClone.DTO.FlairDTO;
using DotNet_RedditClone.DTO.RuleDTO;
using DotNet_RedditClone.DTO.UserDTO;

namespace DotNet_RedditClone.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Community, SimpleCommunityDTO>();
            CreateMap<Community, GetAllCommunityDTO>();
            CreateMap<Community, GetSingleCommunityDTO>();
            CreateMap<AddCommunityDTO, Community>();


            CreateMap<Post, GetAllPostDTO>();
            CreateMap<Post, SimplePostDTO>();
            CreateMap<Post, GetSinglePostDTO>();

            CreateMap<User, GetSingleUserDTO>();


            CreateMap<Comment, GetAllCommentDTO>();

            
            CreateMap<Flair, GetAllFlairDTO>();


            CreateMap<Rule, GetAllRuleDTO>();
        }
    }
}
