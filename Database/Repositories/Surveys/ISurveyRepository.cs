using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Surveys;
public interface ISurveyRepository
{
    Task<Survey> Create(Survey survey);
    Task Delete(int id);
    Task<List<Survey>> GetAll();
    Task<Survey> GetById(int id);
    Task Update(Survey survey);
}