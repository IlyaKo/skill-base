namespace Application.SkillAreas.Model;

public record SkillAreaViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
}
