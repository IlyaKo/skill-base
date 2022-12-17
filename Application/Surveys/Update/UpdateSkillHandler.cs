using AutoMapper;
using Database.Repositories.Surveys;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Update;

public sealed class UpdateSurveyHandler : IRequestHandler<UpdateSurveyRequest, Unit>
{
    private readonly ISurveyRepository repository;
    private readonly IMapper mapper;

    public UpdateSurveyHandler(ISurveyRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSurveyRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"Can't find entity with Id = {request.Id}");
        }

        mapper.Map(request.Dto, entity);
        await repository.Update(entity);

        return Unit.Value;
    }
}
