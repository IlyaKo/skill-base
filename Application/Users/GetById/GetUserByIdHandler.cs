using Application.Users.Model;
using AutoMapper;
using Database.Repositories.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.GetById;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, UserViewModel>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetUserByIdHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserViewModel> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<UserViewModel>(entity);
    }
}
