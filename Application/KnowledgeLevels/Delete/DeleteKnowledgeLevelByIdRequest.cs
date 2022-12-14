using MediatR;

namespace Application.KnowledgeLevels.Delete;

public record DeleteKnowledgeLevelByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
