using AutoMapper;
using Database.Repositories.Subdivisions;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Create;

public sealed class CreateSubdivisionHandler : IRequestHandler<CreateSubdivisionRequest, int>
{
    private readonly ISubdivisionRepository subdivisionRepository;
    private readonly IMapper mapper;

    public CreateSubdivisionHandler(ISubdivisionRepository subdivisionRepository, IMapper mapper)
    {
        this.subdivisionRepository = subdivisionRepository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Subdivision>(request.Dto);
        await subdivisionRepository.Create(entity, request.Dto.SkillAreaIds.ToArray());

        return entity.Id;
    }
}
