using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Repositories.Skills;

internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Area)
            .WithMany()
            .HasForeignKey(x => x.SkillAreaId)
            .IsRequired();
    }
}
