using System;
using System.Collections.Generic;

namespace Shared;

public partial class Media
{
    public int Id { get; set; }

    public string MediaKey { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime DateUpload { get; set; }

    public string? FileName { get; set; }

    public int? Likes { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual User User { get; set; } = null!;

   // public string UserName { get; set; }
}
