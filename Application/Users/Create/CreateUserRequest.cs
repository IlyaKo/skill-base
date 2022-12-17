using Application.Users.Model;
using MediatR;

namespace Application.Users.Create;

public record CreateUserRequest : IRequest<int>
{
    public EditUserDto Dto { get; set; }
}
