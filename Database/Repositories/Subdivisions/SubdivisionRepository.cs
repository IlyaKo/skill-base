using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories.Subdivisions;

public class SubdivisionRepository : RepositoryBase<Subdivision>, ISubdivisionRepository
{
    public SubdivisionRepository(AppContext context) : base(context)
    {

    }

    public async Task<Subdivision> Create(Subdivision subdivision)
      => await base.AddAsync(subdivision);

    public async Task Update(Subdivision subdivision)
        => await base.UpdateAsync(subdivision);

    public async Task<List<Subdivision>> GetAll()
        => await base.GetAllAsync();

    public async Task<List<SkillArea>> GetByAreasBySubdivisionId(int id)
        => await _set.Where(x => x.Id == id).AsNoTracking().SelectMany(x => x.Areas).ToListAsync();

    public async Task<Subdivision> GetById(int id)
        => await base.FindByIdAsync(id);

    public async Task Delete(int id)
    {
        var subdivision = await base.FindByIdAsync(id);
        if (subdivision != null)
        {
            await base.DeleteAsync(subdivision);
        }
    }
}
