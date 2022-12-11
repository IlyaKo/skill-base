using System;

namespace Domain;
public class Survey : EntityBase
{
    public int UserId { get; set; }
    public DateTime Date { get; set; }

    public User User { get; set; }
}
