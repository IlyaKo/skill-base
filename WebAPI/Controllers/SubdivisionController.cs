using Application.Subdivisions.Create;
using Application.Subdivisions.GetById;
using Application.Subdivisions.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public async Task<SubdivisionViewModel> GetById(int id)
    {
        var command = new GetSubdivisionByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(CreateSubdivisionDto dto)
    {
        var command = new CreateSubdivisionRequest { Subdivision = dto };
        return await mediator.Send(command);
    }
}
