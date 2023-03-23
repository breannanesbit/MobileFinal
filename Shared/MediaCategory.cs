using System;
using System.Collections.Generic;

namespace MediaAPI.Data;

public partial class MediaCategory
{
    public int Id { get; set; }

    public int MediaId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Media Media { get; set; } = null!;
}
