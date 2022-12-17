using Application.Skills.Create;
using Application.Skills.Delete;
using Application.Skills.GetById;
using Application.Skills.GetList;
using Application.Skills.Model;
using Application.Skills.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/skills")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly IMediator mediator;

    public SkillController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<SkillViewModel>> GetList()
    {
        var command = new GetSkillListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<SkillViewModel> GetById(int id)
    {
        var command = new GetSkillByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditSkillDto dto)
    {
        var command = new CreateSkillRequest { Dto = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditSkillDto dto)
    {
        var command = new UpdateSkillRequest { Id = id, Dto = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteSkillByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
