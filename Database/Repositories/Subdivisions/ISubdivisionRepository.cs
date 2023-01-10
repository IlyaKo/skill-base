using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Subdivisions;

public interface ISubdivisionRepository
{
    Task<Subdivision> Create(Subdivision subdivision, int[] skillAreaIds);
    Task Delete(int id);
    Task<List<Subdivision>> GetAll();
    Task<List<SkillArea>> GetAreasBySubdivisionId(int id);
    Task<Subdivision> GetById(int id, bool asNoTracking = true);
    Task Update(Subdivision subdivision, int[] skillAreaIds);
    Task Save();
}