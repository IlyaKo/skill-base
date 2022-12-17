using Application.Surveys.Model;
using MediatR;

namespace Application.Surveys.GetById;

public record GetSurveyByIdRequest : IRequest<SurveyViewModel>
{
    public int Id { get; set; }
}
