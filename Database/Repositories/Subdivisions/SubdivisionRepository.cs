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
        => await base.GetAllAsync().Include(x => x.Areas).ToListAsync();

    public async Task<List<SkillArea>> GetAreasBySubdivisionId(int id)
        => await base.FindById(id).SelectMany(x => x.Areas).ToListAsync();

    public async Task<Subdivision> GetById(int id)
        => await base.FindById(id).Include(x => x.Areas).FirstOrDefaultAsync();

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
