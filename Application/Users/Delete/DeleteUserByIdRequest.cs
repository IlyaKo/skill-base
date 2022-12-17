using MediatR;

namespace Application.Users.Delete;

public record DeleteUserByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
