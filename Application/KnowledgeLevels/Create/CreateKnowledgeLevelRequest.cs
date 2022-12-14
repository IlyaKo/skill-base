using Application.KnowledgeLevels.Model;
using MediatR;

namespace Application.KnowledgeLevels.Create;

public record CreateKnowledgeLevelRequest : IRequest<int>
{
    public EditKnowledgeLevelDto Dto { get; set; }
}
