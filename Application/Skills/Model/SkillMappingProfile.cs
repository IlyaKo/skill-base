using AutoMapper;
using Domain;

namespace Application.Skills.Model;

public sealed class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<EditSkillDto, Skill>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Skill, SkillViewModel>();
    }
}
