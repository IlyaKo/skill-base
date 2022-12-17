using Application.Skills.Model;
using AutoMapper;
using Database.Repositories.Skills;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Skills.GetList;

public sealed class GetSkillListHandler : IRequestHandler<GetSkillListRequest, IReadOnlyList<SkillViewModel>>
{
    private readonly ISkillRepository repository;
    private readonly IMapper mapper;

    public GetSkillListHandler(ISkillRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<SkillViewModel>> Handle(GetSkillListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<SkillViewModel>>(list);
    }
}
