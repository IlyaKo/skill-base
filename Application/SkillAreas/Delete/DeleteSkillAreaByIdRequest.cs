using MediatR;

namespace Application.SkillAreas.Delete;

public record DeleteSkillAreaByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
