using System.Collections.Generic;

namespace Domain;

public class User : EntityBase
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsReportUser { get; set; }
    public bool IsSurveyUser { get; set; }
    public string Email { get; set; }

    public ICollection<Subdivision> Subdivisions { get; set; }
    public ICollection<Survey> Surveys { get; set; }
}
