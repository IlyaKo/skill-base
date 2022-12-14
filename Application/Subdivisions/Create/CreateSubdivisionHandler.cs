using AutoMapper;
using Database.Repositories.Subdivisions;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.Create;

public sealed class CreateSubdivisionHandler : IRequestHandler<CreateSubdivisionRequest, int>
{
    private readonly ISubdivisionRepository repository;
    private readonly IMapper mapper;

    public CreateSubdivisionHandler(ISubdivisionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateSubdivisionRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Subdivision>(request.Dto);
        await repository.Create(entity);

        return entity.Id;
    }
}
