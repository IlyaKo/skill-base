using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<List<SkillArea>> GetByIds(List<int> ids, bool asNoTracking = true)
    {
        if (ids.Count == 0)
        {
            return new();
        }

        var skillAreasIds = ids.Distinct().ToList();
        var skillAreas = await base.FindByIds(skillAreasIds, asNoTracking).ToListAsync();
        if (skillAreas.Count < skillAreasIds.Count)
        {
            var wrongIds = skillAreasIds.Except(skillAreas.Select(x => x.Id)).ToList();
            throw new ArgumentException($"Wrong skill area ids: {string.Join(", ", wrongIds)}");
        }

        return skillAreas;
    }

    public async Task Delete(int id)
    {
        var skillArea = await base.FindById(id).FirstOrDefaultAsync();
        if (skillArea != null)
        {
            await base.DeleteAsync(skillArea);
        }
    }
}
