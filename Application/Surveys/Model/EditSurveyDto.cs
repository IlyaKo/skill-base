using Domain;
using System;

namespace Application.Surveys.Model;

public record EditSurveyDto
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
}
