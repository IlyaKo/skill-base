using Application.Subdivisions.Model;
using MediatR;

namespace Application.Subdivisions.Create;

public record CreateSubdivisionRequest : IRequest<int>
{
    public EditSubdivisionDto Dto { get; set; }
}
