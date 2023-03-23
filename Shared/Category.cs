using System;
using System.Collections.Generic;

namespace MediaAPI.Data;

public partial class Category
{
    public int Id { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<MediaCategory> MediaCategories { get; } = new List<MediaCategory>();
}
