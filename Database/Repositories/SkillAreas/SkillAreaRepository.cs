using Domain;
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
        => await base.GetAllAsync();

    public async Task<SkillArea> GetById(int id)
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
