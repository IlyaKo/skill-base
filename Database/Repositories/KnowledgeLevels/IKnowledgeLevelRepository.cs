using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.KnowledgeLevels;

public interface IKnowledgeLevelRepository
{
    Task<KnowledgeLevel> Create(KnowledgeLevel level);
    Task Delete(int id);
    Task<List<KnowledgeLevel>> GetAll();
    Task<KnowledgeLevel> GetById(int id);
    Task Update(KnowledgeLevel level);
}