using AutoMapper;
using Database.Repositories.SkillAreas;
using Database.Repositories.Subdivisions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Update;

public sealed class UpdateSubdivisionHandler : IRequestHandler<UpdateSubdivisionRequest, Unit>
{
    private readonly ISubdivisionRepository subdivisionRepository;
    private readonly ISkillAreaRepository skillAreaRepository;
    private readonly IMapper mapper;

    public UpdateSubdivisionHandler(ISubdivisionRepository subdivisionRepository, ISkillAreaRepository skillAreaRepository, IMapper mapper)
    {
        this.subdivisionRepository = subdivisionRepository;
        this.skillAreaRepository = skillAreaRepository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = await subdivisionRepository.GetById(request.Id);
        if (entity == null)
        {
            throw new ArgumentException($"Can't find entity with Id = {request.Id}");
        }
        mapper.Map(request.Dto, entity);

        entity.Areas = new List<SkillArea>();
        foreach (var skillAreaId in request.Dto.SkillAreaIds)
        {
            var skillArea = await skillAreaRepository.GetById(skillAreaId, asNoTracking: false);
            if (skillArea == null)
            {
                throw new ArgumentException($"Wrong skill area id {skillAreaId}");
            }
            entity.Areas.Add(skillArea);
        }

        await subdivisionRepository.Update(entity);

        return Unit.Value;
    }
}
