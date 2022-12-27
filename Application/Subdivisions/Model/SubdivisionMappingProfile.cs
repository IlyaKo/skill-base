using AutoMapper;
using Domain;

namespace Application.Subdivisions.Model;

public sealed class SubdivisionMappingProfile : Profile
{
    public SubdivisionMappingProfile()
    {
        CreateMap<EditSubdivisionDto, Subdivision>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Subdivision, SubdivisionViewModel>()
            .ForMember(dest => dest.SkillAreas, opt => opt.MapFrom(src => src.Areas));
    }
}
