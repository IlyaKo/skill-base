using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.SkillAreas;

public class SkillAreaRepository : RepositoryBase<SkillArea>, ISkillAreaRepository
{
    public SkillAreaRepository(AppContext context) : base(context)
    {
    }

    public async Task<SkillArea> Create(SkillArea skillArea)
        => await base.AddAsync(skillArea);

    public async Task Update(SkillArea skillArea)
        => await base.UpdateAsync(skillArea);

    public async Task<List<SkillArea>> GetAll()
        => await base.GetAllAsync().ToListAsync();

    public async Task<SkillArea> GetById(int id, bool asNoTracking = true)
        => await base.FindById(id, asNoTracking).FirstOrDefaultAsync();

    public async Task Delete(int id)
    {
        var skillArea = await base.FindById(id).FirstOrDefaultAsync();
        if (skillArea != null)
        {
            await base.DeleteAsync(skillArea);
        }
    }
}
