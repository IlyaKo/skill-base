using Domain;
using System;

namespace Application.Users.Model;

public record EditUserDto
{
    public bool IsAdmin { get; set; }
    public bool IsReportUser { get; set; }
    public bool IsSurveyUser { get; set; }
    public string Email { get; set; }
}
