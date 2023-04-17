using System;
using System.Collections.Generic;

namespace Shared;

public partial class Category
{
    public int Id { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<Media> Media { get; } = new List<Media>();
}
