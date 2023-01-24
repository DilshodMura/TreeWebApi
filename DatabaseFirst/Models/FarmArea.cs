using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class FarmArea
{
    public int Id { get; set; }

    public double Capacity { get; set; }

    public virtual ICollection<Tree> Trees { get; } = new List<Tree>();
}
