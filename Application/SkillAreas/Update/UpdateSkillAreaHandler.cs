using AutoMapper;
using Database.Repositories.SkillAreas;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SkillAreas.Update;

public sealed class UpdateSkillAreaHandler : IRequestHandler<UpdateSkillAreaRequest, Unit>
{
    private readonly ISkillAreaRepository repository;
    private readonly IMapper mapper;

    public UpdateSkillAreaHandler(ISkillAreaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSkillAreaRequest request, CancellationToken cancellationToken)
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
