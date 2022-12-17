using Application.SkillAreas.Model;
using AutoMapper;
using Database.Repositories.SkillAreas;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SkillAreas.GetById;

public sealed class GetSkillAreaByIdHandler : IRequestHandler<GetSkillAreaByIdRequest, SkillAreaViewModel>
{
    private readonly ISkillAreaRepository repository;
    private readonly IMapper mapper;

    public GetSkillAreaByIdHandler(ISkillAreaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<SkillAreaViewModel> Handle(GetSkillAreaByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<SkillAreaViewModel>(entity);
    }
}
