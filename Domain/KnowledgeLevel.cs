namespace Domain;

public class KnowledgeLevel : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Higher is more knowledge
    /// </summary>
    public int Level { get; set; }
}
