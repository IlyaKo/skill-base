using AutoMapper;
using Domain;

namespace Application.Users.Model;

public sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<EditUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<User, UserViewModel>();
    }
}
