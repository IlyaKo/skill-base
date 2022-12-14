using AutoMapper;
using Database.Repositories.KnowledgeLevels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.KnowledgeLevels.Update;

public sealed class UpdateKnowledgeLevelHandler : IRequestHandler<UpdateKnowledgeLevelRequest, Unit>
{
    private readonly IKnowledgeLevelRepository repository;
    private readonly IMapper mapper;

    public UpdateKnowledgeLevelHandler(IKnowledgeLevelRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateKnowledgeLevelRequest request, CancellationToken cancellationToken)
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
