using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories.Subdivisions;

public class SubdivisionRepository : RepositoryBase<Subdivision>, ISubdivisionRepository
{
    public SubdivisionRepository(AppContext context) : base(context)
    {

    }

    public async Task<Subdivision> Create(Subdivision subdivision, int[] skillAreaIds)
    {
        await base.AddAsync(subdivision, saveChanges: false);
        subdivision.Areas = await GetSkillAreasById(skillAreaIds);

        await base.SaveAsync();

        return subdivision;
    }

    public async Task Update(Subdivision subdivision, int[] skillAreaIds)
    {
        subdivision.Areas = await GetSkillAreasById(skillAreaIds);

        await base.SaveAsync();
    }

    private async Task<List<SkillArea>> GetSkillAreasById(int[] ids)
    {
        if (ids.Length == 0)
        {
            return new();
        }

        var skillAreasIds = ids.Distinct().ToList();
        var skillAreas = await base._context.Set<SkillArea>().Where(x => ids.Contains(x.Id)).ToListAsync();
        if (skillAreas.Count < skillAreasIds.Count)
        {
            var wrongIds = skillAreasIds.Except(skillAreas.Select(x => x.Id)).ToList();
            throw new ArgumentException($"Wrong skill area ids: {string.Join(", ", wrongIds)}");
        }

        return skillAreas;
    }

    public async Task<List<Subdivision>> GetAll()
        => await base.GetAllAsync().Include(x => x.Areas).ToListAsync();

    public async Task<List<SkillArea>> GetAreasBySubdivisionId(int id)
        => await base.FindById(id).SelectMany(x => x.Areas).ToListAsync();

    public async Task<Subdivision> GetById(int id, bool asNoTracking = true)
        => await base.FindById(id, asNoTracking).Include(x => x.Areas).FirstOrDefaultAsync();

    public async Task Delete(int id)
    {
        var subdivision = await base.FindById(id).FirstOrDefaultAsync();
        if (subdivision != null)
        {
            await base.DeleteAsync(subdivision);
        }
    }

    public Task Save()
        => base.SaveAsync();

}
