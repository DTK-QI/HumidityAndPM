using System;
using System.Collections.Generic;

namespace HumidityAndPMDataConnect.Models;

public partial class Pm25value
{
    public int Pmindex { get; set; }

    public string? CountryId { get; set; }

    public double? Pm25 { get; set; }

    public DateTime? RecordTime { get; set; }

    public virtual CountryInfo? Country { get; set; }
}
