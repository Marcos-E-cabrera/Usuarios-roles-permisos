using System;
using System.Collections.Generic;

namespace IntroASP.Models;

public partial class Brand
{
    public int BranId { get; set; }

    public string? Name { get; set; }

    public virtual Beer? Beer { get; set; }
}
