using AutoMapper;
using Database.Repositories.KnowledgeLevels;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.KnowledgeLevels.Create;

public sealed class CreateKnowledgeLevelHandler : IRequestHandler<CreateKnowledgeLevelRequest, int>
{
    private readonly IKnowledgeLevelRepository repository;
    private readonly IMapper mapper;

    public CreateKnowledgeLevelHandler(IKnowledgeLevelRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateKnowledgeLevelRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<KnowledgeLevel>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
