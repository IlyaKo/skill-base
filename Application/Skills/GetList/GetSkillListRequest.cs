using Application.Skills.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.Skills.GetList;

public record GetSkillListRequest : IRequest<IReadOnlyList<SkillViewModel>>
{
}
