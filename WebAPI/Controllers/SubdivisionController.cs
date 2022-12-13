using Application.Subdivisions.Create;
using Application.Subdivisions.Delete;
using Application.Subdivisions.GetById;
using Application.Subdivisions.GetList;
using Application.Subdivisions.Model;
using Application.Subdivisions.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/subdivisions")]
[ApiController]
public class SubdivisionController : ControllerBase
{
    private readonly IMediator mediator;

    public SubdivisionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<SubdivisionViewModel>> GetList()
    {
        var command = new GetSubdivisionListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<SubdivisionViewModel> GetById(int id)
    {
        var command = new GetSubdivisionByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditSubdivisionDto dto)
    {
        var command = new CreateSubdivisionRequest { Subdivision = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditSubdivisionDto dto)
    {
        var command = new UpdateSubdivisionRequest { Id = id, Subdivision = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteSubdivisionByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
