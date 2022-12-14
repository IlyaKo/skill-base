using Application.KnowledgeLevels.Model;
using AutoMapper;
using Database.Repositories.KnowledgeLevels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.KnowledgeLevels.GetById;

public sealed class GetKnowledgeLevelByIdHandler : IRequestHandler<GetKnowledgeLevelByIdRequest, KnowledgeLevelViewModel>
{
    private readonly IKnowledgeLevelRepository repository;
    private readonly IMapper mapper;

    public GetKnowledgeLevelByIdHandler(IKnowledgeLevelRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<KnowledgeLevelViewModel> Handle(GetKnowledgeLevelByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<KnowledgeLevelViewModel>(entity);
    }
}
