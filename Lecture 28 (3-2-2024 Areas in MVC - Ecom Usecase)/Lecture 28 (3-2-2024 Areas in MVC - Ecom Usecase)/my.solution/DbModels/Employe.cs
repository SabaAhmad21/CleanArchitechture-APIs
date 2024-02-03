using System;
using System.Collections.Generic;

namespace DbModels;

public partial class Employe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsGraduated { get; set; }
}
