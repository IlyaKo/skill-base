using Application.Users.Model;
using MediatR;

namespace Application.Users.Update;

public record UpdateUserRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditUserDto Dto { get; set; }
}
