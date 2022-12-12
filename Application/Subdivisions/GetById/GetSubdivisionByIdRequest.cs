using Application.Subdivisions.Model;
using MediatR;

namespace Application.Subdivisions.GetById;

public record GetSubdivisionByIdRequest : IRequest<SubdivisionViewModel>
{
    public int Id { get; set; }
}
