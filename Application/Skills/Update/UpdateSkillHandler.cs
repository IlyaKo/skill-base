using AutoMapper;
using Database.Repositories.Skills;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Skills.Update;

public sealed class UpdateSkillHandler : IRequestHandler<UpdateSkillRequest, Unit>
{
    private readonly ISkillRepository repository;
    private readonly IMapper mapper;

    public UpdateSkillHandler(ISkillRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSkillRequest request, CancellationToken cancellationToken)
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
