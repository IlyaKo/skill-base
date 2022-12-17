using Application.Users.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.Users.GetList;

public record GetUserListRequest : IRequest<IReadOnlyList<UserViewModel>>
{
}
