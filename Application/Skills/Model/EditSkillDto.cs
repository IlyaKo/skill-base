namespace Application.Skills.Model;

public record EditSkillDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public int SkillAreaId { get; set; }
}
