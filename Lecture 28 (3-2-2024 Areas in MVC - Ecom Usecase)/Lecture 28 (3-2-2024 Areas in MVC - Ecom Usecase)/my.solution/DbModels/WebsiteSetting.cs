using System;
using System.Collections.Generic;

namespace DbModels;

public partial class WebsiteSetting
{
    public int Id { get; set; }

    public string SettingName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public bool IsStagging { get; set; }

    public bool IsAcceptness { get; set; }

    public bool IsProduction { get; set; }

    public int SettingId { get; set; }
}
