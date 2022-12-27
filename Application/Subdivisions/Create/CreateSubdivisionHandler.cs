using AutoMapper;
using Database.Repositories.SkillAreas;
using Database.Repositories.Subdivisions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Create;

public sealed class CreateSubdivisionHandler : IRequestHandler<CreateSubdivisionRequest, int>
{
    private readonly ISubdivisionRepository subdivisionRepository;
    private readonly ISkillAreaRepository skillAreaRepository;
    private readonly IMapper mapper;

    public CreateSubdivisionHandler(ISubdivisionRepository subdivisionRepository, ISkillAreaRepository skillAreaRepository, IMapper mapper)
    {
        this.subdivisionRepository = subdivisionRepository;
        this.skillAreaRepository = skillAreaRepository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Subdivision>(request.Dto);
        await subdivisionRepository.Create(entity);

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
        if (entity.Areas.Count > 0)
        {
            await subdivisionRepository.Save();
        }
        return entity.Id;
    }
}
