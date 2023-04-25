using System;
using System.Collections.Generic;

namespace Shared;

public partial class Comment
{
    public int Id { get; set; }

    public string Comment1 { get; set; } = null!;

    public int UserId { get; set; }

    public int MediaId { get; set; }

    //public virtual Media Media { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
