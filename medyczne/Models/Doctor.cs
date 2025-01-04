using System;
using System.Collections.Generic;

namespace medyczne.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Type { get; set; }

    public TimeOnly Starttime { get; set; }

    public TimeOnly Endtime { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
