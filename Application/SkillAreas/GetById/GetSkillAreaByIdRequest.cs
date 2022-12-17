using Application.SkillAreas.Model;
using MediatR;

namespace Application.SkillAreas.GetById;

public record GetSkillAreaByIdRequest : IRequest<SkillAreaViewModel>
{
    public int Id { get; set; }
}
