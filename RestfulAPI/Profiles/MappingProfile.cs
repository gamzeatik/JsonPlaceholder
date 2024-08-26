using AutoMapper;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;

namespace RestfulAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreatePostRequest -> Post
            CreateMap<CreatePostRequest, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
            // UpdatePostRequest -> Post
            CreateMap<UpdatePostRequest, Post>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.UserId, opt => opt.Ignore());
            // Post -> PostResponse
            CreateMap<Post, PostResponse>();
        }
    }
}
