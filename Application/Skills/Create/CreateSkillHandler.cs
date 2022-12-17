using AutoMapper;
using Database.Repositories.Skills;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Skills.Create;

public sealed class CreateSkillHandler : IRequestHandler<CreateSkillRequest, int>
{
    private readonly ISkillRepository repository;
    private readonly IMapper mapper;

    public CreateSkillHandler(ISkillRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Skill>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
