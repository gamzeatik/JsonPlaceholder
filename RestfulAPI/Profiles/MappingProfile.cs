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
            // Post -> PostResponse
            CreateMap<Post, PostResponse>();
            // CreateUserRequest -> User
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
            // CreateAddressRequest -> Address
            CreateMap<CreateAddressRequest, Address>()
                .ForMember(dest => dest.Geo, opt => opt.MapFrom(src => src.Geo));
            // CreateGeoRequest -> Geo
            CreateMap<CreateGeoRequest, Geo>();
            // CreateCompanyRequest -> Company
            CreateMap<CreateCompanyRequest, Company>();
            // User -> UserResponse
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
            // Address -> AddressResponse
            CreateMap<Address, AddressResponse>()
                .ForMember(dest => dest.Geo, opt => opt.MapFrom(src => src.Geo));
            // Geo -> GeoResponse
            CreateMap<Geo, GeoResponse>();
            // Company -> CompanyResponse
            CreateMap<Company, CompanyResponse>();
        }
    }
}
