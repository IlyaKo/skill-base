using Application.Subdivisions.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.Subdivisions.GetList;

public record GetSubdivisionListRequest : IRequest<IReadOnlyList<SubdivisionViewModel>>
{
}
