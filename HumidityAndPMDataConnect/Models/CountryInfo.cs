using System;
using System.Collections.Generic;

namespace HumidityAndPMDataConnect.Models;

public partial class CountryInfo
{
    public string CountryId { get; set; } = null!;

    public string? CountryName { get; set; }

    public virtual ICollection<Pm25value> Pm25values { get; set; } = new List<Pm25value>();

    public virtual ICollection<WeatherValue> WeatherValues { get; set; } = new List<WeatherValue>();
}
