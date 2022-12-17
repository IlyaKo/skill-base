namespace Application.Users.Model;

public record UserViewModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsReportUser { get; set; }
    public bool IsSurveyUser { get; set; }
    public string Email { get; set; }

}
