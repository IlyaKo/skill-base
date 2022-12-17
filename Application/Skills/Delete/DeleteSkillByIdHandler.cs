using Database.Repositories.Skills;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Skills.Delete;

public sealed class DeleteSkillByIdHandler : IRequestHandler<DeleteSkillByIdRequest, Unit>
{
    private readonly ISkillRepository repository;

    public DeleteSkillByIdHandler(ISkillRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteSkillByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
