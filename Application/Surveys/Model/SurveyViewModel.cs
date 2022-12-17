using Application.Users.Model;
using Domain;
using System;

namespace Application.Surveys.Model;

public record SurveyViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public UserViewModel User { get; set; }

}
