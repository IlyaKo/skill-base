using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.GetById;
using Application.Users.GetList;
using Application.Users.Model;
using Application.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<UserViewModel>> GetList()
    {
        var command = new GetUserListRequest();
        return await mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<UserViewModel> GetById(int id)
    {
        var command = new GetUserByIdRequest { Id = id };
        return await mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> Create(EditUserDto dto)
    {
        var command = new CreateUserRequest { Dto = dto };
        return await mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, EditUserDto dto)
    {
        var command = new UpdateUserRequest { Id = id, Dto = dto };
        await mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var command = new DeleteUserByIdRequest { Id = id };
        await mediator.Send(command);
    }
}
