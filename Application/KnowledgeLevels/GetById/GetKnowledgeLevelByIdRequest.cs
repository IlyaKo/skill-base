using Application.KnowledgeLevels.Model;
using MediatR;

namespace Application.KnowledgeLevels.GetById;

public record GetKnowledgeLevelByIdRequest : IRequest<KnowledgeLevelViewModel>
{
    public int Id { get; set; }
}
