using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Repositories.KnowledgeLevels;

internal class KnowledgeLevelConfiguration : IEntityTypeConfiguration<KnowledgeLevel>
{
    public void Configure(EntityTypeBuilder<KnowledgeLevel> builder)
    {
        builder.ToTable("KnowledgeLevels");

        builder.HasKey(x => x.Id);

        builder.HasData(new[] 
        {   
            new KnowledgeLevel { Id = 1, Name = "No knowledge", Level = 10},
            new KnowledgeLevel { Id = 2, Name = "Experienced", Level = 20},
            new KnowledgeLevel { Id = 3, Name = "Proficient", Level = 30},
            new KnowledgeLevel { Id = 4, Name = "Expert", Level = 40},
        });
    }
}
