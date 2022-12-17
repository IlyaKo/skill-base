using Application.Users.Model;
using AutoMapper;
using Database.Repositories.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.GetList;

public sealed class GetUserListHandler : IRequestHandler<GetUserListRequest, IReadOnlyList<UserViewModel>>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetUserListHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<UserViewModel>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<UserViewModel>>(list);
    }
}
