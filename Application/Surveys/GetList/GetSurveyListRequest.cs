using Application.Surveys.Model;
using MediatR;
using System.Collections.Generic;

namespace Application.Surveys.GetList;

public record GetSurveyListRequest : IRequest<IReadOnlyList<SurveyViewModel>>
{
}
