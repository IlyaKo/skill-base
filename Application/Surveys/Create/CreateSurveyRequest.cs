using Application.Surveys.Model;
using MediatR;

namespace Application.Surveys.Create;

public record CreateSurveyRequest : IRequest<int>
{
    public EditSurveyDto Dto { get; set; }
}
