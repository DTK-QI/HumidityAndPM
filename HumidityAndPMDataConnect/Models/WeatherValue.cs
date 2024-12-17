using System;
using System.Collections.Generic;

namespace HumidityAndPMDataConnect.Models;

public partial class WeatherValue
{
    public int WeatherIndex { get; set; }

    public string? CountryId { get; set; }
    public string? ValueId { get; set; }

    public string? ValueName { get; set; }

    public double? Value { get; set; }

    public DateTime? RecordTime { get; set; }

    public virtual CountryInfo? Country { get; set; }
}
