using Database.Repositories.Subdivisions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Delete;

public sealed class DeleteSubdivisionByIdHandler : IRequestHandler<DeleteSubdivisionByIdRequest, Unit>
{
    private readonly ISubdivisionRepository repository;

    public DeleteSubdivisionByIdHandler(ISubdivisionRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteSubdivisionByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
