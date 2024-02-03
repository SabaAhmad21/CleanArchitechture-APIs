using System;
using System.Collections.Generic;

namespace DbModels;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsEnable { get; set; }

    public bool IsDeleted { get; set; }
}
