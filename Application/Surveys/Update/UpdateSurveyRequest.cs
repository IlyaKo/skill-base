using Application.Surveys.Model;
using MediatR;

namespace Application.Surveys.Update;

public record UpdateSurveyRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public EditSurveyDto Dto { get; set; }
}
