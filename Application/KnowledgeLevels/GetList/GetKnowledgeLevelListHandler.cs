using Application.KnowledgeLevels.Model;
using AutoMapper;
using Database.Repositories.KnowledgeLevels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.KnowledgeLevels.GetList;

public sealed class GetKnowledgeLevelListHandler : IRequestHandler<GetKnowledgeLevelListRequest, IReadOnlyList<KnowledgeLevelViewModel>>
{
    private readonly IKnowledgeLevelRepository repository;
    private readonly IMapper mapper;

    public GetKnowledgeLevelListHandler(IKnowledgeLevelRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<KnowledgeLevelViewModel>> Handle(GetKnowledgeLevelListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<KnowledgeLevelViewModel>>(list);
    }
}
