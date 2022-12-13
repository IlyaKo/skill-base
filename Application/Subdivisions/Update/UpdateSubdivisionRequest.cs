using Application.Subdivisions.Model;
using MediatR;

namespace Application.Subdivisions.Update;

public record UpdateSubdivisionRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditSubdivisionDto Subdivision { get; set; }
}
