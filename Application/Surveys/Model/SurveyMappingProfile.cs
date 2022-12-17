using AutoMapper;
using Domain;

namespace Application.Surveys.Model;

public sealed class SurveyMappingProfile : Profile
{
    public SurveyMappingProfile()
    {
        CreateMap<EditSurveyDto, Survey>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Survey, SurveyViewModel>();
    }
}
