using System.ComponentModel.DataAnnotations;

namespace No1B.Entities;

public class Subscriber : BaseEntity<Guid>
{

    [EmailAddress, Required, MaxLength(150)]
    public string Email { get; set; }

    public DateTime SubscribedOn { get; set; }
}