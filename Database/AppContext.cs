using Database.Repositories.KnowledgeLevels;
using Database.Repositories.SkillAreas;
using Database.Repositories.Skills;
using Database.Repositories.Subdivisions;
using Database.Repositories.Surveys;
using Database.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options ) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SkillConfiguration());
        builder.ApplyConfiguration(new SubdivisionConfiguration());
        builder.ApplyConfiguration(new SkillAreaConfiguration());
        builder.ApplyConfiguration(new SurveyConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());    
        builder.ApplyConfiguration(new KnowledgeLevelConfiguration());
    }
}
