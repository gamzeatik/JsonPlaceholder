using AutoMapper;
using RestfulAPI.DTOs.Requests;
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
        }
    }
}
