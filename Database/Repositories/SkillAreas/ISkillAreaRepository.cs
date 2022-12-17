using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.SkillAreas;

public interface ISkillAreaRepository
{
    Task<SkillArea> Create(SkillArea skillArea);
    Task Delete(int id);
    Task<List<SkillArea>> GetAll();
    Task<SkillArea> GetById(int id);
    Task Update(SkillArea skillArea);
}