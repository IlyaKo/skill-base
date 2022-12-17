using AutoMapper;
using Database.Repositories.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Update;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Unit>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public UpdateUserHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"Can't find entity with Id = {request.Id}");
        }

        mapper.Map(request.Dto, entity);
        await repository.Update(entity);

        return Unit.Value;
    }
}
