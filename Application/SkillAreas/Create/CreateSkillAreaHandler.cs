using AutoMapper;
using Database.Repositories.SkillAreas;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SkillAreas.Create;

public sealed class CreateSkillAreaHandler : IRequestHandler<CreateSkillAreaRequest, int>
{
    private readonly ISkillAreaRepository repository;
    private readonly IMapper mapper;

    public CreateSkillAreaHandler(ISkillAreaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSkillAreaRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<SkillArea>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
