using Application.Skills.Model;
using MediatR;

namespace Application.Skills.GetById;

public record GetSkillByIdRequest : IRequest<SkillViewModel>
{
    public int Id { get; set; }
}
