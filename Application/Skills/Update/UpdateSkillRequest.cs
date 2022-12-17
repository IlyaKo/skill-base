using Application.Skills.Model;
using MediatR;

namespace Application.Skills.Update;

public record UpdateSkillRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditSkillDto Dto { get; set; }
}
