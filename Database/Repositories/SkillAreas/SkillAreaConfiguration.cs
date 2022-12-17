using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Repositories.SkillAreas;

internal class SkillAreaConfiguration : IEntityTypeConfiguration<SkillArea>
{
    public void Configure(EntityTypeBuilder<SkillArea> builder)
    {
        builder.ToTable("SkillAreas");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Skills)
            .WithOne(y => y.Area)
            .HasForeignKey(y => y.SkillAreaId);

        builder
            .HasData(
                new[]
                {
                    new SkillArea { Id = 1, Name = "Common", Order = 1 }
                });
    }
}
