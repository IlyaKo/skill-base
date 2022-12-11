using Database.Repositories.Subdivisions;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;
[Route("api/subdivisions")]
[ApiController]
public class SubdivisionController : ControllerBase
{
    private readonly ISubdivisionRepository repository;

    public SubdivisionController(ISubdivisionRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<ICollection<Subdivision>> GetAll()
        => await repository.GetAll();

    [HttpGet("{id}")]
    public async Task<Subdivision> GetById(int id)
        => await repository.GetById(id);
}
