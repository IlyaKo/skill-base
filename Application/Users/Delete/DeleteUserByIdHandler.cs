using Database.Repositories.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Delete;

public sealed class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdRequest, Unit>
{
    private readonly IUserRepository repository;

    public DeleteUserByIdHandler(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
