using System;
using System.Collections.Generic;

namespace Shared;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Username { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Media> Media { get; } = new List<Media>();
}
