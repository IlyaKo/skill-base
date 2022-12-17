using Database.Repositories.SkillAreas;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SkillAreas.Delete;

public sealed class DeleteSkillAreaByIdHandler : IRequestHandler<DeleteSkillAreaByIdRequest, Unit>
{
    private readonly ISkillAreaRepository repository;

    public DeleteSkillAreaByIdHandler(ISkillAreaRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteSkillAreaByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
