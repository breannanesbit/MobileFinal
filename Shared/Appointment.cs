using System;
using System.Collections.Generic;

namespace Shared;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
