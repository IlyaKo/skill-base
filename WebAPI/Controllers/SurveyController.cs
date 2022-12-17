using Application.Surveys.Create;
using Application.Surveys.Delete;
using Application.Surveys.GetById;
using Application.Surveys.GetList;
using Application.Surveys.Model;
using Application.Surveys.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/surveys")]
[ApiController]
public class SurveyController : ControllerBase
{
    private readonly IMediator mediator;

    public SurveyController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<SurveyViewModel>> GetList()
    {
        var command = new GetSurveyListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<SurveyViewModel> GetById(int id)
    {
        var command = new GetSurveyByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditSurveyDto dto)
    {
        var command = new CreateSurveyRequest { Dto = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditSurveyDto dto)
    {
        var command = new UpdateSurveyRequest { Id = id, Dto = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteSurveyByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
