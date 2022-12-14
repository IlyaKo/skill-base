using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.KnowledgeLevels;

public class KnowledgeLevelRepository : RepositoryBase<KnowledgeLevel>, IKnowledgeLevelRepository
{
    public KnowledgeLevelRepository(AppContext context) : base(context)
    {
    }

    public async Task<KnowledgeLevel> Create(KnowledgeLevel level)
        => await base.AddAsync(level);

    public async Task Update(KnowledgeLevel level)
        => await base.UpdateAsync(level);

    public async Task<List<KnowledgeLevel>> GetAll()
        => await base.GetAllAsync();

    public async Task<KnowledgeLevel> GetById(int id)
        => await base.FindByIdAsync(id);

    public async Task Delete(int id)
    {
        var entity = await base.FindByIdAsync(id);
        if (entity != null)
        {
            await base.DeleteAsync(entity);
        }
    }
}
