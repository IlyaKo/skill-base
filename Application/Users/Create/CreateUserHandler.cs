using AutoMapper;
using Database.Repositories.Users;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Create;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, int>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public CreateUserHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
