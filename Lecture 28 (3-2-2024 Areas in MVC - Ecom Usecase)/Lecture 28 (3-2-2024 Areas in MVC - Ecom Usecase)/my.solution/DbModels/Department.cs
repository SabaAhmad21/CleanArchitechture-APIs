using System;
using System.Collections.Generic;

namespace DbModels;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int OrderBy { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
