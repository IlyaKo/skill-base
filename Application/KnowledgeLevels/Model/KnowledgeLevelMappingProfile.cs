using AutoMapper;
using Domain;

namespace Application.KnowledgeLevels.Model;

public sealed class KnowledgeLevelMappingProfile : Profile
{
    public KnowledgeLevelMappingProfile()
    {
        CreateMap<EditKnowledgeLevelDto, KnowledgeLevel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<KnowledgeLevel, KnowledgeLevelViewModel>();
    }
}
