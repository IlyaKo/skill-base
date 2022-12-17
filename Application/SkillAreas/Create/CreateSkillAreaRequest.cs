using Application.SkillAreas.Model;
using MediatR;

namespace Application.SkillAreas.Create;

public record CreateSkillAreaRequest : IRequest<int>
{
    public EditSkillAreaDto Dto { get; set; }
}
