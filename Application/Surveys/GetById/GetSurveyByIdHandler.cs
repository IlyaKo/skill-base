using Application.Surveys.Model;
using AutoMapper;
using Database.Repositories.Surveys;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.GetById;

public sealed class GetSurveyByIdHandler : IRequestHandler<GetSurveyByIdRequest, SurveyViewModel>
{
    private readonly ISurveyRepository repository;
    private readonly IMapper mapper;

    public GetSurveyByIdHandler(ISurveyRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<SurveyViewModel> Handle(GetSurveyByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<SurveyViewModel>(entity);
    }
}
