using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Repositories.Surveys;

internal class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany(y => y.Surveys)
            .IsRequired();
    }
}
