using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories.Skills;

internal class SkillRepository : RepositoryBase<Skill>, ISkillRepository
{
    public SkillRepository(AppContext context) : base(context)
    {
    }

    public async Task<Skill> Create(Skill skill)
        => await base.AddAsync(skill);

    public async Task Update(Skill skillArea)
        => await base.UpdateAsync(skillArea);

    public async Task<List<Skill>> GetAll()
        => await base.GetAllAsync();

    public async Task<List<Skill>> GetByAreaId(int id)
        => await _set.Where(x => x.SkillAreaId == id).AsNoTracking().ToListAsync();

    public async Task<Skill> GetById(int id)
        => await base.FindByIdAsync(id);

    public async Task Delete(int id)
    {
        var skillArea = await base.FindByIdAsync(id);
        if (skillArea != null)
        {
            await base.DeleteAsync(skillArea);
        }
    }
}
