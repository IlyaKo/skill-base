using System.Collections.Generic;

namespace Domain;

public class SkillArea : EntityBase
{
    public string Name { get; set; }
    public int Order { get; set; }

    public ICollection<Skill> Skills { get; set; }
}
