using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Surveys;

public class SurveyRepository : RepositoryBase<Survey>, ISurveyRepository
{
    public SurveyRepository(AppContext context) : base(context)
    {

    }

    public async Task<Survey> Create(Survey survey)
      => await base.AddAsync(survey);

    public async Task Update(Survey survey)
        => await base.UpdateAsync(survey);

    public async Task<List<Survey>> GetAll()
        => await base.GetAllAsync().ToListAsync();

    public async Task<Survey> GetById(int id)
        => await base.FindById(id).FirstOrDefaultAsync();

    public async Task Delete(int id)
    {
        var survey = await base.FindById(id).FirstOrDefaultAsync();
        if (survey != null)
        {
            await base.DeleteAsync(survey);
        }
    }
}
