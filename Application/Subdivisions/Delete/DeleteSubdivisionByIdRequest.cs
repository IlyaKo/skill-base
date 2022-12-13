using MediatR;

namespace Application.Subdivisions.Delete;

public record DeleteSubdivisionByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
