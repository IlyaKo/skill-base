using Application.Users.Model;
using MediatR;

namespace Application.Users.GetById;

public record GetUserByIdRequest : IRequest<UserViewModel>
{
    public int Id { get; set; }
}
