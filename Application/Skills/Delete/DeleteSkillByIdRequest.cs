using MediatR;

namespace Application.Skills.Delete;

public record DeleteSkillByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
