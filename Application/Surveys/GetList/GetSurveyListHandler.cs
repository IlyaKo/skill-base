using Application.Surveys.Model;
using AutoMapper;
using Database.Repositories.Surveys;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.GetList;

public sealed class GetSurveyListHandler : IRequestHandler<GetSurveyListRequest, IReadOnlyList<SurveyViewModel>>
{
    private readonly ISurveyRepository repository;
    private readonly IMapper mapper;

    public GetSurveyListHandler(ISurveyRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<SurveyViewModel>> Handle(GetSurveyListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<SurveyViewModel>>(list);
    }
}
