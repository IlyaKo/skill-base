using Database.Repositories.KnowledgeLevels;
using Database.Repositories.Subdivisions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.KnowledgeLevels.Delete;

public sealed class DeleteKnowledgeLevelByIdHandler : IRequestHandler<DeleteKnowledgeLevelByIdRequest, Unit>
{
    private readonly IKnowledgeLevelRepository repository;

    public DeleteKnowledgeLevelByIdHandler(IKnowledgeLevelRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteKnowledgeLevelByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
