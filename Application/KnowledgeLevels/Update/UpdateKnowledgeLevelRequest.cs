using Application.KnowledgeLevels.Model;
using MediatR;

namespace Application.KnowledgeLevels.Update;

public record UpdateKnowledgeLevelRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditKnowledgeLevelDto Dto { get; set; }
}
