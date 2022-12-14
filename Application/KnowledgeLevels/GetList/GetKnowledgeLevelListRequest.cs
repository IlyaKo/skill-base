using Application.KnowledgeLevels.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.KnowledgeLevels.GetList;

public record GetKnowledgeLevelListRequest : IRequest<IReadOnlyList<KnowledgeLevelViewModel>>
{
}
