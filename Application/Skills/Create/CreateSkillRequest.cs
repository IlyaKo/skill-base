using Application.Skills.Model;
using MediatR;

namespace Application.Skills.Create;

public record CreateSkillRequest : IRequest<int>
{
    public EditSkillDto Dto { get; set; }
}
