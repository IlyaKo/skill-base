using Application.Subdivisions.Model;
using AutoMapper;
using Database.Repositories.Subdivisions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.GetById;

public sealed class GetSubdivisionByIdHandler : IRequestHandler<GetSubdivisionByIdRequest, SubdivisionViewModel>
{
    private readonly ISubdivisionRepository repository;
    private readonly IMapper mapper;

    public GetSubdivisionByIdHandler(ISubdivisionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<SubdivisionViewModel> Handle(GetSubdivisionByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetById(request.Id);
        return mapper.Map<SubdivisionViewModel>(entity);
    }
}
