using AutoMapper;
using Database.Repositories.Surveys;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Create;

public sealed class CreateSurveyHandler : IRequestHandler<CreateSurveyRequest, int>
{
    private readonly ISurveyRepository repository;
    private readonly IMapper mapper;

    public CreateSurveyHandler(ISurveyRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSurveyRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Survey>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
