using System;
using System.Collections.Generic;

namespace medyczne.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateTime Datetime { get; set; }

    public bool Approved { get; set; }
}
