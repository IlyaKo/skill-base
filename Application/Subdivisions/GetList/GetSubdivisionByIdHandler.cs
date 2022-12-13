using Application.Subdivisions.Model;
using AutoMapper;
using Database.Repositories.Subdivisions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subdivisions.GetList;

public sealed class GetSubdivisionListHandler : IRequestHandler<GetSubdivisionListRequest, IReadOnlyList<SubdivisionViewModel>>
{
    private readonly ISubdivisionRepository repository;
    private readonly IMapper mapper;

    public GetSubdivisionListHandler(ISubdivisionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyList<SubdivisionViewModel>> Handle(GetSubdivisionListRequest request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAll();
        return mapper.Map<IReadOnlyList<SubdivisionViewModel>>(list);
    }
}
