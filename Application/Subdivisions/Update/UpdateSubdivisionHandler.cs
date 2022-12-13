using AutoMapper;
using Database.Repositories.Subdivisions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Update;

public sealed class UpdateSubdivisionHandler : IRequestHandler<UpdateSubdivisionRequest, Unit>
{
    private readonly ISubdivisionRepository repository;
    private readonly IMapper mapper;

    public UpdateSubdivisionHandler(ISubdivisionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"Can't find entity with Id = {request.Id}");
        }

        mapper.Map(request.Subdivision, entity);

        return Unit.Value;
    }
}
