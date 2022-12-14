namespace Application.KnowledgeLevels.Model;

public record EditKnowledgeLevelDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
}
