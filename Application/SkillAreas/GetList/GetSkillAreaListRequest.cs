using Application.SkillAreas.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.SkillAreas.GetList;

public record GetSkillAreaListRequest : IRequest<IReadOnlyList<SkillAreaViewModel>>
{
}
