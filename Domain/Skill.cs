namespace Domain;

public class Skill : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public int SkillAreaId { get; set; }

    public SkillArea Area { get; set; }
}
