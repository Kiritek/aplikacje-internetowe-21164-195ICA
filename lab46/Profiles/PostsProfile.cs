using AutoMapper;

namespace RestApiAppv2.Profiles
{
    public class PostsProfile: Profile
    {
        public PostsProfile()
        {
            CreateMap<Entities.Post, Models.PostDto>();
            CreateMap<Models.PostForCreationDto, Entities.Post>();
            CreateMap<Models.PostForUpdateDto, Entities.Post>();
        }
    }
}
