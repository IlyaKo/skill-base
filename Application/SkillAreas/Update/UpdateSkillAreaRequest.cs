using Application.SkillAreas.Model;
using MediatR;

namespace Application.SkillAreas.Update;

public record UpdateSkillAreaRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditSkillAreaDto Dto { get; set; }
}
