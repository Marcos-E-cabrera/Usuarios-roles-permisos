using System;
using System.Collections.Generic;

namespace MVCEntityFramework.Models.DB;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? Fecha { get; set; }
}
