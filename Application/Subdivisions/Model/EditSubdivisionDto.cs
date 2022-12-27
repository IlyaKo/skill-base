using System.Collections.Generic;

namespace Application.Subdivisions.Model;

public record EditSubdivisionDto
{
    public string Name { get; set; }

    public List<int> SkillAreaIds { get; set; }
}
