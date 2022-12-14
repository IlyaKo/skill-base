using Application.KnowledgeLevels.Create;
using Application.KnowledgeLevels.Delete;
using Application.KnowledgeLevels.GetById;
using Application.KnowledgeLevels.GetList;
using Application.KnowledgeLevels.Model;
using Application.KnowledgeLevels.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/knowledge-levels")]
[ApiController]
public class KnowledgeLevelController : ControllerBase
{
    private readonly IMediator mediator;

    public KnowledgeLevelController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<KnowledgeLevelViewModel>> GetList()
    {
        var command = new GetKnowledgeLevelListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<KnowledgeLevelViewModel> GetById(int id)
    {
        var command = new GetKnowledgeLevelByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditKnowledgeLevelDto dto)
    {
        var command = new CreateKnowledgeLevelRequest { Dto = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditKnowledgeLevelDto dto)
    {
        var command = new UpdateKnowledgeLevelRequest { Id = id, Dto = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteKnowledgeLevelByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
