using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Tree
{
    public int Id { get; set; }

    public int Sort { get; set; }

    public int Type { get; set; }

    public double MaxHeight { get; set; }

    public double MaxSquare { get; set; }

    public double MaxFruitlness { get; set; }

    public int Amount { get; set; }

    public int AreaId { get; set; }

    public virtual FarmArea Area { get; set; } = null!;
}
