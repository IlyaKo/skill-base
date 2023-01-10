using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Repositories.Subdivisions;

internal class SubdivisionConfiguration : IEntityTypeConfiguration<Subdivision>
{
    public void Configure(EntityTypeBuilder<Subdivision> builder)
    {
        builder.ToTable("Subdivisions");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Areas)
            .WithMany(y => y.Subdivisions)
            .UsingEntity(j => j.ToTable("SubdivisionAreas"));

        builder
            .HasMany(x => x.Users)
            .WithMany(y => y.Subdivisions)
            .UsingEntity(j => j.ToTable("UserSubdivisions"));
    }
}
