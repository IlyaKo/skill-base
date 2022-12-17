using MediatR;

namespace Application.Surveys.Delete;

public record DeleteSurveyByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
