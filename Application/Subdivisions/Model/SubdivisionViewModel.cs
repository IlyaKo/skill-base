using Application.SkillAreas.Model;
using System.Collections.Generic;

namespace Application.Subdivisions.Model;

public record SubdivisionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SkillAreaViewModel> SkillAreas { get; set; }
}
