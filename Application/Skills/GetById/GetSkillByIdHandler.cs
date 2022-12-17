using Application.Skills.Model;
using AutoMapper;
using Database.Repositories.Skills;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Skills.GetById;

public sealed class GetSkillByIdHandler : IRequestHandler<GetSkillByIdRequest, SkillViewModel>
{
    private readonly ISkillRepository repository;
    private readonly IMapper mapper;

    public GetSkillByIdHandler(ISkillRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<SkillViewModel> Handle(GetSkillByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<SkillViewModel>(entity);
    }
}
