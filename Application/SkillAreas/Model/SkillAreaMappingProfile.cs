using AutoMapper;
using Domain;

namespace Application.SkillAreas.Model;

public sealed class SkillAreaMappingProfile : Profile
{
    public SkillAreaMappingProfile()
    {
        CreateMap<EditSkillAreaDto, SkillArea>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<SkillArea, SkillAreaViewModel>();
    }
}
