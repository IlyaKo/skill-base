using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Subdivisions;
public interface ISubdivisionRepository
{
    Task<Subdivision> Create(Subdivision subdivision);
    Task Delete(int id);
    Task<List<Subdivision>> GetAll();
    Task<List<SkillArea>> GetByAreasBySubdivisionId(int id);
    Task<Subdivision> GetById(int id);
    Task Update(Subdivision subdivision);
}