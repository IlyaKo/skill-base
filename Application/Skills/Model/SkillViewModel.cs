using Application.SkillAreas.Model;

namespace Application.Skills.Model;

public record SkillViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public SkillAreaViewModel SkillArea { get; set; }
}
