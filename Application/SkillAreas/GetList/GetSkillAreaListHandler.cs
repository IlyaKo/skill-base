using Application.SkillAreas.Model;
using AutoMapper;
using Database.Repositories.SkillAreas;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SkillAreas.GetList;

public sealed class GetSkillAreaListHandler : IRequestHandler<GetSkillAreaListRequest, IReadOnlyList<SkillAreaViewModel>>
{
    private readonly ISkillAreaRepository repository;
    private readonly IMapper mapper;

    public GetSkillAreaListHandler(ISkillAreaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<SkillAreaViewModel>> Handle(GetSkillAreaListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<SkillAreaViewModel>>(list);
    }
}
