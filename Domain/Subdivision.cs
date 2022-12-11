using System.Collections.Generic;

namespace Domain;

public class Subdivision : EntityBase
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<SkillArea> Areas { get; set; }
}

