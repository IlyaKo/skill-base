using Application.SkillAreas.Create;
using Application.SkillAreas.Delete;
using Application.SkillAreas.GetById;
using Application.SkillAreas.GetList;
using Application.SkillAreas.Model;
using Application.SkillAreas.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/skill-areas")]
[ApiController]
public class SkillAreaController : ControllerBase
{
    private readonly IMediator mediator;

    public SkillAreaController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<SkillAreaViewModel>> GetList()
    {
        var command = new GetSkillAreaListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<SkillAreaViewModel> GetById(int id)
    {
        var command = new GetSkillAreaByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditSkillAreaDto dto)
    {
        var command = new CreateSkillAreaRequest { Dto = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditSkillAreaDto dto)
    {
        var command = new UpdateSkillAreaRequest { Id = id, Dto = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteSkillAreaByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
