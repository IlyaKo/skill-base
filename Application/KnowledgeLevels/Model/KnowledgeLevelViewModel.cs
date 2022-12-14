namespace Application.KnowledgeLevels.Model;

public record KnowledgeLevelViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Higher is more knowledge
    /// </summary>
    public int Level { get; set; }
}
