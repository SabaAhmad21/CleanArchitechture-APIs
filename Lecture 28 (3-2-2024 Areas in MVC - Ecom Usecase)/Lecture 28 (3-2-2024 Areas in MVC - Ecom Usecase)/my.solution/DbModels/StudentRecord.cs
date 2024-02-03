using System;
using System.Collections.Generic;

namespace DbModels;

public partial class StudentRecord
{
    public Guid Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string RollNumber { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string StdGender { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string? ImgUrl { get; set; }
}
