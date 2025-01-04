using System;
using System.Collections.Generic;

namespace medyczne.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string? Password { get; set; }
}
