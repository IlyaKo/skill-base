using AutoMapper;
using Database.Repositories.Subdivisions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Update;

public sealed class UpdateSubdivisionHandler : IRequestHandler<UpdateSubdivisionRequest, Unit>
{
    private readonly ISubdivisionRepository subdivisionRepository;
    private readonly IMapper mapper;

    public UpdateSubdivisionHandler(ISubdivisionRepository subdivisionRepository, IMapper mapper)
    {
        this.subdivisionRepository = subdivisionRepository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = await subdivisionRepository.GetById(request.Id, tracking: true);
        if (entity == null)
        {
            throw new ArgumentException($"Can't find entity with Id = {request.Id}");
        }
        mapper.Map(request.Dto, entity);

        await subdivisionRepository.Update(entity, request.Dto.SkillAreaIds.ToArray());

        return Unit.Value;
    }
}
