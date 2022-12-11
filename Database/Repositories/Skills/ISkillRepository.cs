using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Skills;
internal interface ISkillRepository
{
    Task<Skill> Create(Skill skill);
    Task Delete(int id);
    Task<List<Skill>> GetAll();
    Task<List<Skill>> GetByAreaId(int id);
    Task<Skill> GetById(int id);
    Task Update(Skill skillArea);
}