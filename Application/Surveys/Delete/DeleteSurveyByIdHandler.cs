using Database.Repositories.Surveys;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Surveys.Delete;

public sealed class DeleteSurveyByIdHandler : IRequestHandler<DeleteSurveyByIdRequest, Unit>
{
    private readonly ISurveyRepository repository;

    public DeleteSurveyByIdHandler(ISurveyRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Unit> Handle(DeleteSurveyByIdRequest request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);

        return Unit.Value;
    }
}
